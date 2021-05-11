using OperacionFuegoQuasar.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace OperacionFuegoQuasar.Transversal
{
    public static class TransformationHelper
    {

        public static Position Translate(this Position position, Position reference = null, bool inverse = false)
        {
            reference = reference == null ? position : reference;
            position.x -= inverse ? -reference.x : reference.x;
            position.y -= inverse ? -reference.y : reference.y;
            return position;
        }
        public static Position Rotate(this Position position, Position reference = null, bool inverse = false)
        {
            reference = reference == null ? position : reference;
            var x2 = Math.Pow(reference.x, 2);
            var y2 = Math.Pow(reference.y, 2);
            var h = Math.Pow(x2 + y2, 0.5);

            var sin = reference.y / h;
            sin = inverse ? sin : -sin;
            var cos = reference.x / h;

            var x = position.x * cos - position.y * sin;
            var y = position.x * sin + position.y * cos;
            position.x = x;
            position.y = y;
            return position;
        }

        public static Position Trilateracion(this Satellite s1, Satellite s2, Satellite s3)
        {
            var translate = s1.position;


            s1.Translate();
            s2.Translate(translate);
            var rotate = s2.position;
            s2.Rotate();
            s3.Translate(translate).Rotate(rotate);

            var d = s2.x;
            var i = s3.x;
            var j = s3.y;
            var r12 = Math.Pow(s1.distance, 2);
            var r22 = Math.Pow(s2.distance, 2);
            var r32 = Math.Pow(s3.distance, 2);
            var d2 = Math.Pow(d, 2);
            var i2 = Math.Pow(i, 2);
            var j2 = Math.Pow(j, 2);

            var yy = (r12 - r32 + i2 + j2) / (2 * j);

            double x = (r12 - r22 + d2) / (2 * d);
            double y = yy - (i * x / j);

            var error = Math.Pow(Math.Abs(Math.Pow(x, 2) + Math.Pow(y, 2) - Math.Pow(s1.distance, 2)), 0.5);
            var desviation = Convert.ToDouble(Environment.GetEnvironmentVariable("ERROR"));

            if (error < desviation || error > desviation)
                throw new Exception("Información no correcta");
            Position position = new Position(x, y);
            position.Rotate(rotate, true).Translate(position, true);
            return position;
        }
        //public static Position Trilateracion(this Satellite s1, Satellite s2, Satellite s3)
        //{
        //    var translate = s1.position;
        //    s1.Translate();
        //    s2.Translate(translate);
        //    s3.Translate(translate);

        //    var r1 = Math.Pow(s1.distance, 2);
        //    var r2 = Math.Pow(s2.distance, 2);
        //    var r3 = Math.Pow(s3.distance, 2);

        //    var a = s2.x;
        //    var b = s2.y;
        //    var c = s3.x;
        //    var d = s3.y;

        //    var a2 = Math.Pow(a, 2);
        //    var b2 = Math.Pow(b, 2);
        //    var c2 = Math.Pow(c, 2);
        //    var d2 = Math.Pow(d, 2);

        //    var xx = (r1 - r2 + a2 + b2) / (2 * a);
        //    var yy = (r1 - r3 + c2 + d2) / (2 * c);
        //    var y = (xx -yy) / ((b / a) - (d / c));
        //    var x = xx - (b*y/a);

        //    var error = Math.Pow(Math.Abs(Math.Pow(x, 2) + Math.Pow(y, 2) Z- Math.Pow(s1.distance, 2)), 0.5);
        //    var desviation = Convert.ToDouble(Environment.GetEnvironmentVariable("ERROR"));

        //    if (error<desviation || error> desviation)
        //        throw new Exception();
        //    Position position = new Position(x, y);
        //    position.Translate(position, true);
        //    return position;
        //}
    }
}
