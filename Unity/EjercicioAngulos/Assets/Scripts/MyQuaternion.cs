using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    
 
    class MyQuaternion
    {
        public struct Quaternion {
            public double x;
            public double y;
            public double z;
            public double w;
        };
       
        public Quaternion MakeQuat (double x, double y, double z, double w) {

            Quaternion Quat;
            Quat.x = x;
            Quat.y = y;
            Quat.z = z;
            Quat.w = w;
            return Quat;
        }

        public Quaternion Normalize(Quaternion Quat) {

            Quaternion quat = Quat;
            double modulo = Math.Sqrt(Math.Pow(quat.x, 2) + Math.Pow(quat.y, 2) + Math.Pow(quat.z, 2) + Math.Pow(quat.w, 2));
            quat.x = quat.x / modulo;
            quat.y = quat.y / modulo;
            quat.z = quat.z / modulo;
            quat.w = quat.w / modulo;
            return quat;
        }

        public double Modulo(Quaternion Quat) {
           return Math.Sqrt(Math.Pow(Quat.x, 2) + Math.Pow(Quat.y, 2) + Math.Pow(Quat.z, 2) + Math.Pow(Quat.w, 2));           
        }

        public Quaternion Multiply(Quaternion Quat1 , Quaternion Quat2) {
            Quaternion quat1 = Normalize(Quat1);
            Quaternion quat2 = Normalize(Quat2);
            Quaternion quat3;
            quat3.x = quat1.w * quat2.x + quat1.x * quat2.w + quat1.y * quat2.z - quat1.z * quat2.y;
            quat3.y = quat1.w * quat2.y - quat1.x * quat2.z + quat1.y * quat2.w + quat1.z * quat2.x;
            quat3.z = quat1.w * quat2.z + quat1.x * quat2.y - quat1.y * quat2.x + quat1.z * quat2.w;
            quat3.w = quat1.w * quat2.w - quat1.x * quat2.x - quat1.y * quat2.y - quat1.z * quat2.z;
            return quat3;
        }

    }
}
