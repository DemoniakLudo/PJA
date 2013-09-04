﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ConvImgCpc {
	public class LockBitmap {
		private Bitmap source = null;
		private IntPtr Iptr = IntPtr.Zero;
		BitmapData bitmapData = null;

		public byte[] Pixels { get; set; }
		public int Depth { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		public LockBitmap(Bitmap source) {
			this.source = source;
			Width = source.Width;
			Height = source.Height;
			Depth = Bitmap.GetPixelFormatSize(source.PixelFormat);
			Pixels = new byte[Width * Height * (Depth / 8)];
		}

		public void LockBits() {
			bitmapData = source.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Iptr = bitmapData.Scan0;
			Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
		}

		public Bitmap UnlockBits() {
			Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);
			source.UnlockBits(bitmapData);
			return source;
		}

		public int GetPixel(int pixelX, int pixelY) {
			int adr = ((pixelY * Width) + pixelX) << 2;
			return Pixels[adr] + (Pixels[adr + 1] << 8) + (Pixels[adr + 2] << 16);
		}

		public RvbColor GetPixelColor(int pixelX, int pixelY) {
			int adr = ((pixelY * Width) + pixelX) << 2;
			return new RvbColor(Pixels[adr] + (Pixels[adr + 1] << 8) + (Pixels[adr + 2] << 16));
		}

		public void GetPixel(int pixelX, int pixelY, ref int r, ref int v, ref int b) {
			int adr = ((pixelY * Width) + pixelX) << 2;
			r = Pixels[adr];
			v = Pixels[adr + 1];
			b = Pixels[adr + 2];
		}

		public void AddGetPixel(int pixelX, int pixelY, ref int r, ref int v, ref int b) {
			int adr = ((pixelY * Width) + pixelX) << 2;
			r += Pixels[adr];
			v += Pixels[adr + 1];
			b += Pixels[adr + 2];
		}

		public void SetPixel(int pixelX, int pixelY, int color) {
			int adr = ((pixelY * Width) + pixelX) << 2;
			Pixels[adr++] = (byte)(color);
			Pixels[adr++] = (byte)(color >> 8);
			Pixels[adr++] = (byte)(color >> 16);
			Pixels[adr] = 0xFF;
		}

		public void CopyPixel(int xs, int ys, int xd, int yd, int nb) {
			int adrd = ((yd * Width) + xd) << 2;
			int adr = ((ys * Width) + xs) << 2;
			for (; nb-- > 0; ) {
				Pixels[adrd++] = Pixels[adr];
				Pixels[adrd++] = Pixels[adr + 1];
				Pixels[adrd++] = Pixels[adr + 2];
				Pixels[adrd++] = 255;
			}
		}
	}

	public class RvbColor {
		public byte r, v, b;

		public RvbColor(byte compR, byte compV, byte compB) {
			r = compR;
			v = compV;
			b = compB;
		}

		public RvbColor(int value) {
			r = (byte)value;
			v = (byte)(value >> 8);
			b = (byte)(value >> 16);
		}

		public int GetColor { get { return (int)(r + (v << 8) + (b << 16)); } }
		public int GetColorARGB { get { return GetColor + (255 << 24); } }
	}
}