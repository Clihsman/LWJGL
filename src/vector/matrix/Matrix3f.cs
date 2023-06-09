﻿using System;
using System.Text;

namespace lwjgl.vector
{
	[Serializable]
	public class Matrix3f : Matrix
	{
		public float m00;
		public float m01;
		public float m02;
		public float m10;
		public float m11;
		public float m12;
		public float m20;
		public float m21;
		public float m22;

		public Matrix3f ()
		{
			setIdentity ();
		}

		public Matrix3f load (Matrix3f src)
		{
			return load (src, this);
		}

		public static Matrix3f load (Matrix3f src, Matrix3f dest)
		{
			if (dest == null) {
				dest = new Matrix3f ();
			}
			dest.m00 = src.m00;
			dest.m10 = src.m10;
			dest.m20 = src.m20;
			dest.m01 = src.m01;
			dest.m11 = src.m11;
			dest.m21 = src.m21;
			dest.m02 = src.m02;
			dest.m12 = src.m12;
			dest.m22 = src.m22;
			return dest;
		}

		public static Matrix3f add (Matrix3f left, Matrix3f right, Matrix3f dest)
		{
			if (dest == null) {
				dest = new Matrix3f ();
			}
			left.m00 += right.m00;
			left.m01 += right.m01;
			left.m02 += right.m02;
			left.m10 += right.m10;
			left.m11 += right.m11;
			left.m12 += right.m12;
			left.m20 += right.m20;
			left.m21 += right.m21;
			left.m22 += right.m22;
			return dest;
		}

		public static Matrix3f sub (Matrix3f left, Matrix3f right, Matrix3f dest)
		{
			if (dest == null) {
				dest = new Matrix3f ();
			}
			left.m00 -= right.m00;
			left.m01 -= right.m01;
			left.m02 -= right.m02;
			left.m10 -= right.m10;
			left.m11 -= right.m11;
			left.m12 -= right.m12;
			left.m20 -= right.m20;
			left.m21 -= right.m21;
			left.m22 -= right.m22;
			return dest;
		}

		public static Matrix3f mul (Matrix3f left, Matrix3f right, Matrix3f dest)
		{
			if (dest == null) {
				dest = new Matrix3f ();
			}
			float m00 = left.m00 * right.m00 + left.m10 * right.m01 + left.m20 * right.m02;
			float m01 = left.m01 * right.m00 + left.m11 * right.m01 + left.m21 * right.m02;
			float m02 = left.m02 * right.m00 + left.m12 * right.m01 + left.m22 * right.m02;
			float m10 = left.m00 * right.m10 + left.m10 * right.m11 + left.m20 * right.m12;
			float m11 = left.m01 * right.m10 + left.m11 * right.m11 + left.m21 * right.m12;
			float m12 = left.m02 * right.m10 + left.m12 * right.m11 + left.m22 * right.m12;
			float m20 = left.m00 * right.m20 + left.m10 * right.m21 + left.m20 * right.m22;
			float m21 = left.m01 * right.m20 + left.m11 * right.m21 + left.m21 * right.m22;
			float m22 = left.m02 * right.m20 + left.m12 * right.m21 + left.m22 * right.m22;
			dest.m00 = m00;
			dest.m01 = m01;
			dest.m02 = m02;
			dest.m10 = m10;
			dest.m11 = m11;
			dest.m12 = m12;
			dest.m20 = m20;
			dest.m21 = m21;
			dest.m22 = m22;
			return dest;
		}

		public static Vector3f transform (Matrix3f left, Vector3f right, Vector3f dest)
		{
			if (dest == null) {
				dest = new Vector3f ();
			}
			float x = left.m00 * right.x + left.m10 * right.y + left.m20 * right.z;
			float y = left.m01 * right.x + left.m11 * right.y + left.m21 * right.z;
			float z = left.m02 * right.x + left.m12 * right.y + left.m22 * right.z;
			dest.x = x;
			dest.y = y;
			dest.z = z;
			return dest;
		}

		public override Matrix transpose ()
		{
			return transpose (this, this);
		}

		public Matrix3f transpose (Matrix3f dest)
		{
			return transpose (this, dest);
		}

		public static Matrix3f transpose (Matrix3f src, Matrix3f dest)
		{
			if (dest == null)
		       dest = new Matrix3f (); 
			float m00 = src.m00;
			float m01 = src.m10;
			float m02 = src.m20;
			float m10 = src.m01;
			float m11 = src.m11;
			float m12 = src.m21;
			float m20 = src.m02;
			float m21 = src.m12;
			float m22 = src.m22;
			dest.m00 = m00;
			dest.m01 = m01;
			dest.m02 = m02;
			dest.m10 = m10;
			dest.m11 = m11;
			dest.m12 = m12;
			dest.m20 = m20;
			dest.m21 = m21;
			dest.m22 = m22;
			return dest;
		}

		public override float determinant ()
		{
			return this.m00 * (this.m11 * this.m22 - this.m12 * this.m21) + this.m01 * (this.m12 * this.m20 - this.m10 * this.m22) + this.m02 * (this.m10 * this.m21 - this.m11 * this.m20);
		}

		public override String ToString ()
		{
			StringBuilder buf = new StringBuilder ();
			buf.Append (this.m00).Append (' ').Append (this.m10).Append (' ').Append (this.m20).Append (' ').Append ('\n');
			buf.Append (this.m01).Append (' ').Append (this.m11).Append (' ').Append (this.m21).Append (' ').Append ('\n');
			buf.Append (this.m02).Append (' ').Append (this.m12).Append (' ').Append (this.m22).Append (' ').Append ('\n');
			return buf.ToString ();
		}

		public override Matrix invert ()
		{
			return invert (this, this);
		}

		public static Matrix3f invert (Matrix3f src, Matrix3f dest)
		{
			float determinant = src.determinant ();
			if (determinant != 0.0F) {
				if (dest == null) {
					dest = new Matrix3f ();
				}
				float determinant_inv = 1.0F / determinant;
				float t00 = src.m11 * src.m22 - src.m12 * src.m21;
				float t01 = -src.m10 * src.m22 + src.m12 * src.m20;
				float t02 = src.m10 * src.m21 - src.m11 * src.m20;
				float t10 = -src.m01 * src.m22 + src.m02 * src.m21;
				float t11 = src.m00 * src.m22 - src.m02 * src.m20;
				float t12 = -src.m00 * src.m21 + src.m01 * src.m20;
				float t20 = src.m01 * src.m12 - src.m02 * src.m11;
				float t21 = -src.m00 * src.m12 + src.m02 * src.m10;
				float t22 = src.m00 * src.m11 - src.m01 * src.m10;
				dest.m00 = t00 * determinant_inv;
				dest.m11 = t11 * determinant_inv;
				dest.m22 = t22 * determinant_inv;
				dest.m01 = t10 * determinant_inv;
				dest.m10 = t01 * determinant_inv;
				dest.m20 = t02 * determinant_inv;
				dest.m02 = t20 * determinant_inv;
				dest.m12 = t21 * determinant_inv;
				dest.m21 = t12 * determinant_inv;
				return dest;
			} 
			return null;
		}

		public override Matrix negate ()
		{
			return negate (this);
		}

		public Matrix3f negate (Matrix3f dest)
		{
			return negate (this, dest);
		}

		public static Matrix3f negate (Matrix3f src, Matrix3f dest)
		{
			if (dest == null) {
				dest = new Matrix3f ();
			}
			dest.m00 = -src.m00;
			dest.m01 = -src.m02;
			dest.m02 = -src.m01;
			dest.m10 = -src.m10;
			dest.m11 = -src.m12;
			dest.m12 = -src.m11;
			dest.m20 = -src.m20;
			dest.m21 = -src.m22;
			dest.m22 = -src.m21;
			return dest;
		}

		public override Matrix setIdentity ()
		{
			return setIdentity (this);
		}

		public static Matrix3f setIdentity (Matrix3f m)
		{
			m.m00 = 1.0F;
			m.m01 = 0.0F;
			m.m02 = 0.0F;
			m.m10 = 0.0F;
			m.m11 = 1.0F;
			m.m12 = 0.0F;
			m.m20 = 0.0F;
			m.m21 = 0.0F;
			m.m22 = 1.0F;
			return m;
		}

		public override Matrix setZero ()
		{
			return setZero (this);
		}

		public static Matrix3f setZero (Matrix3f m)
		{
			m.m00 = 0.0F;
			m.m01 = 0.0F;
			m.m02 = 0.0F;

			m.m10 = 0.0F;
			m.m11 = 0.0F;
			m.m12 = 0.0F;

			m.m20 = 0.0F;
			m.m21 = 0.0F;
			m.m22 = 0.0F;
			return m;
		}

		public static implicit operator OpenTK.Matrix3(Matrix3f matrix){
			return new OpenTK.Matrix3 (
				matrix.m00,matrix.m01,matrix.m02,
				matrix.m10,matrix.m11,matrix.m12,
				matrix.m20,matrix.m21,matrix.m22
			);
		}

	}
}

