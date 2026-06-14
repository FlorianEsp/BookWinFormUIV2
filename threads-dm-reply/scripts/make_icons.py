#!/usr/bin/env python3
"""Génère les icônes PNG (16/48/128) de l'extension.

Les binaires ne sont pas versionnés sur GitHub (l'API de contenu stocke le
texte, pas le binaire). Lancez ce script une fois après le clone, avant de
charger l'extension non empaquetée :

    python3 scripts/make_icons.py
"""
import os
import struct
import zlib

OUT_DIR = os.path.join(os.path.dirname(__file__), "..", "icons")


def make_png(path, size, bg=(0, 149, 246, 255), fg=(255, 255, 255, 255)):
    w = h = size
    px = [[list(bg) for _ in range(w)] for _ in range(h)]

    # Bulle de message
    m = max(2, size // 6)
    bw0, bw1 = m, w - m
    bh0, bh1 = m, int(h * 0.62)
    for y in range(bh0, bh1):
        for x in range(bw0, bw1):
            px[y][x] = list(fg)

    # Petite pointe sous la bulle
    for y in range(bh1, min(h - 1, bh1 + size // 5)):
        x0 = bw0 + size // 6
        x1 = x0 + max(1, (bh1 + size // 5 - y))
        for x in range(x0, min(x1, bw1)):
            px[y][x] = list(fg)

    # Trois points dans la bulle
    cy = (bh0 + bh1) // 2
    r = max(1, size // 16)
    for frac in (0.3, 0.5, 0.7):
        cx = int(bw0 + (bw1 - bw0) * frac)
        for y in range(cy - r, cy + r + 1):
            for x in range(cx - r, cx + r + 1):
                if (x - cx) ** 2 + (y - cy) ** 2 <= r * r and 0 <= y < h and 0 <= x < w:
                    px[y][x] = list(bg)

    raw = bytearray()
    for y in range(h):
        raw.append(0)
        for x in range(w):
            raw += bytes(px[y][x])

    def chunk(typ, data):
        c = struct.pack(">I", len(data)) + typ + data
        return c + struct.pack(">I", zlib.crc32(typ + data) & 0xFFFFFFFF)

    sig = b"\x89PNG\r\n\x1a\n"
    ihdr = struct.pack(">IIBBBBB", w, h, 8, 6, 0, 0, 0)
    idat = zlib.compress(bytes(raw), 9)
    with open(path, "wb") as f:
        f.write(sig + chunk(b"IHDR", ihdr) + chunk(b"IDAT", idat) + chunk(b"IEND", b""))
    print("écrit", path)


def main():
    os.makedirs(OUT_DIR, exist_ok=True)
    for s in (16, 48, 128):
        make_png(os.path.join(OUT_DIR, "icon%d.png" % s), s)


if __name__ == "__main__":
    main()
