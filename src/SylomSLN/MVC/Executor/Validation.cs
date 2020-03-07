using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Executor {

    public class Validation {

        public static bool Valid(params object[] p) {
            foreach (var v in p) {
                if (v is string) {
                    if (string.IsNullOrEmpty(v.ToString())) {
                        return false;
                    }
                } else if (v == null) {
                    return false;
                }
            }
            return true;
        }

        public static bool OnlyNumber(params object[] n) {
            try {
                foreach (var v in n) {
                    if (v.ToString().Contains(',') || v.ToString().Contains('.')) {
                        Convert.ToDecimal(v);
                    } else {
                        Convert.ToInt32(v);
                    }
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public static bool OnlyNumber(bool t, params object[] n) {
            try {
                if (t) {//Decimal
                    foreach (var v in n) {
                        Convert.ToDecimal(v);
                    }
                    //decimal temp = Convert.ToDecimal(n);
                } else {//Integer
                    foreach (var v in n) {
                        Convert.ToInt32(v);
                    }
                    //int temp = Convert.ToInt32(n);
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }
    }
}