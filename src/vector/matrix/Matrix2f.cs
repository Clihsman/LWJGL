﻿using System;
using System.Text;

namespace lwjgl.vector
{
	[Serializable]
	public class Matrix2f : Matrix
	{
		public float m00;
		public float m01;
		public float m10;
		public float m11;

		public Matrix2f ()
		{
			setIdentity ();
		}

		public Matrix2f (Matrix2f src)
		{
			load (src);
		}

		public Matrix2f load (Matrix2f src)
		{
			return load (src, this);
		}

		public static Matrix2f load (Matrix2f src, Matrix2f dest)
		{
			if (dest == null) {
				dest = new Matrix2f ();
			}
			dest.m00 = src.m00;
			dest.m01 = src.m01;
			dest.m10 = src.m10;
			dest.m11 = src.m11;
			return dest;
			/*     */
		}

		public static Matrix2f add (Matrix2f left, Matrix2f right, Matrix2f dest)
		{
			if (dest == null) {
				dest = new Matrix2f ();
			}
			left.m00 += right.m00;
			left.m01 += right.m01;
			left.m10 += right.m10;
			left.m11 += right.m11;
			return dest;
		}

		public static Matrix2f sub (Matrix2f left, Matrix2f right, Matrix2f dest)
		{
			if (dest == null) {
				dest = new Matrix2f ();
			}
			left.m00 -= right.m00;
			left.m01 -= right.m01;
			left.m10 -= right.m10;
			left.m11 -= right.m11;  
			return dest;
		}

		public static Matrix2f mul (Matrix2f left, Matrix2f right, Matrix2f dest)
		{
			if (dest == null) {
				dest = new Matrix2f ();
			}
			float m00 = left.m00 * right.m00 + left.m10 * right.m01;
			float m01 = left.m01 * right.m00 + left.m11 * right.m01;
			float m10 = left.m00 * right.m10 + left.m10 * right.m11;
			float m11 = left.m01 * right.m10 + left.m11 * right.m11;
			dest.m00 = m00;
			dest.m01 = m01;
			dest.m10 = m10;
			dest.m11 = m11;
			return dest;
		}

		public static Vector2f transform (Matrix2f left, Vector2f right, Vector2f dest)
		{
			if (dest == null) {
				dest = new Vector2f ();
			}
			float x = left.m00 * right.x + left.m10 * right.y;
			float y = left.m01 * right.x + left.m11 * right.y;
			dest.x = x;
			dest.y = y;
			return dest;
		}

		public override Matrix transpose ()
		{
			return transpose (this);
		}

		public Matrix2f transpose (Matrix2f dest)
		{
			return transpose (this, dest);
		}

		public static Matrix2f transpose (Matrix2f src, Matrix2f dest)
		{
			if (dest == null) {
				dest = new Matrix2f ();
			}
			float m01 = src.m10;
			float m10 = src.m01; 
			dest.m01 = m01;
			dest.m10 = m10;
			return dest;
		}

		public override Matrix invert ()
		{
			return invert (this, this);
		}

		public static Matrix2f invert (Matrix2f src, Matrix2f dest)
		{
			float determinant = src.determinant ();
			if (determinant != 0.0F) {
				if (dest == null)
					dest = new Matrix2f (); 
				float determinant_inv = 1.0F / determinant;
				float t00 = src.m11 * determinant_inv;
				float t01 = -src.m01 * determinant_inv;
				float t11 = src.m00 * determinant_inv;
				float t10 = -src.m10 * determinant_inv;
				dest.m00 = t00;
				dest.m01 = t01;
				dest.m10 = t10;
				dest.m11 = t11;
				return dest;
			} 
			return null;
		}

		public String toString ()
		{
			StringBuilder buf = new StringBuilder ();
			buf.Append (this.m00).Append (' ').Append (this.m10).Append (' ').Append ('\n');
			buf.Append (this.m01).Append (' ').Append (this.m11).Append (' ').Append ('\n');
			return buf.ToString ();
		}

		public override Matrix negate ()
		{
			return negate (this);
		}

		public Matrix2f negate (Matrix2f dest)
		{
			return negate (this, dest);
		}

		public static Matrix2f negate (Matrix2f src, Matrix2f dest)
		{
			if (dest == null) {
				dest = new Matrix2f ();
			}
			dest.m00 = -src.m00;
			dest.m01 = -src.m01;
			dest.m10 = -src.m10;
			dest.m11 = -src.m11;
			return dest;

		}

		public override Matrix setIdentity ()
		{
			return setIdentity (this);
		}

		public static Matrix2f setIdentity (Matrix2f src)
		{
			src.m00 = 1.0F;
			src.m01 = 0.0F;
			src.m10 = 0.0F;
			src.m11 = 1.0F;
			return src;
		}

		public override Matrix setZero ()
		{
			return setZero (this);
		}

		public static Matrix2f setZero (Matrix2f src)
		{
			src.m00 = 0.0F;
			src.m01 = 0.0F;
			src.m10 = 0.0F;
			src.m11 = 0.0F;	
			return src;		
		}

		public override float determinant ()
		{
			return this.m00 * this.m11 - this.m01 * this.m10;
		}

		public static implicit operator OpenTK.Matrix2(Matrix2f matrix){
			return new OpenTK.Matrix2 (matrix.m00,matrix.m01,matrix.m10,matrix.m11);
		}

	}
}

