﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace mposAdmin
{
    public static class SessionData
    {

        static SessionData()
        {
            string host;
            string dbuser;
            string dbpassword;
            string db;
            string comport;
            int loginMode = 1;//1 for cashier 2 for kot and 3 for admin
            bool userAuth = false;
            string authType = "U";
            string user;
            string userid;
            double cartTotal = 0;
            int itemCount = 0;
            double serviceCharge = 10;
            double discount = 0;
            double change;
            double payamount;
            int guest;
            string tabel = "";
            long newOrderId;
            int orderType = 0;
            bool cashdisplayon = true;
            string md5Password;


            //Receipt = 1, Kot=2, Bot = 3
            int receiptType;

        }

        //SET USER ID
        public static string userid { get; private set; }
        public static void SetUserId(string id)
        {
            userid = id;
        }

        //SET HOST
        public static string host { get; private set; }
        public static void SetHost(string hostname)
        {
            host = hostname;
        }

        //SET DB USER
        public static string dbuser { get; private set; }
        public static void SetDbUser(string user)
        {
            dbuser = user;
        }

        //SET DB PASSWORD
        public static string dbpassword { get; private set; }
        public static void SetDbUserPassword(string dbpass)
        {
            dbpassword = dbpass;
        }

        //SET DB 
        public static string db { get; private set; }
        public static void SetDb(string database)
        {
            db = database;
        }

        //SET COMPORT
        public static string comport { get; private set; }
        public static void SetComPort(string port)
        {
            comport = port;
        }

        //set login mode
        public static int loginMode { get; private set; }
        public static void SetLoginMode(int mode)
        {
            loginMode = mode;
        }

        //set user authentication
        public static bool userAuth { get; private set; }
        public static void SetUserAuth(bool auth)
        {
            userAuth = auth;
        }

        //Uer Type
        public static string authType { get; private set; }
        public static void setauthType(string auth_type)
        {
            authType = auth_type;
        }

        //set user
        public static string user { get; private set; }
        public static void setUser(string u)
        {
            user = u;
        }



        //cal cart total
        public static double cartTotal { get; private set; }
        public static void SetCartTotal(double subtotal)
        {
            cartTotal += subtotal;
        }

        public static void UpdateCartTotal(double delprice)
        {
            cartTotal = cartTotal - delprice;
        }

        //cat count Items
        public static int itemCount { get; private set; }
        public static void SetCartItemCount(int qty)
        {
            itemCount += qty;
        }

        public static void DeleteItem()
        {
            itemCount = itemCount - 1;
        }

        //set service charge
        public static double serviceCharge { get; private set; }
        public static void SetSeviceCharge()
        {
            serviceCharge = 10;
        }

        //set discount
        public static double discount { get; private set; }
        public static void SetDiscount(double dis)
        {
            discount = dis;
        }
        //Set change money
        public static double change { get; private set; }
        public static void SetChageMoney(double cash)
        {
            change = cash - payamount;
        }

        public static double payamount { get; private set; }
        public static void SetPayamount(double paid)
        {
            payamount = paid;
        }


        //gests details
        public static int guest { get; private set; }
        public static void SetGuest(int count)
        {
            guest = count;
        }

        //tabel details
        public static string tabel { get; private set; }
        public static void SetTabelDetails(string tbl)
        {
            tabel = tbl;

            //if (String.IsNullOrEmpty(tabel))
            //{
            //   tabel += tbl;
            //}
            // else {
            //   tabel += "-" + tbl;
            //  } 
        }

        //Set New order id
        public static long newOrderId { get; private set; }
        public static void SetNewOrderId(long orderid)
        {
            newOrderId = orderid;
        }


        //set order type
        public static int orderType { get; private set; }
        public static void SetOrderType(int ortype)
        {
            orderType = ortype;
        }

        //cash display on off

        public static bool cashdisplayon { get; private set; }
        public static void SetCashdisplayStatus(bool cashdisplaystatus)
        {
            cashdisplayon = cashdisplaystatus;
        }

        public static int receiptType { get; private set; }
        public static void SetReceiptType(int rtype)
        {
            receiptType = rtype;
        }


        public static string md5Password { get; private set; }
        public static void SetMd5PasswordToConvert(string source)
        {
            StringBuilder sb = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] md5HashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(source));
                foreach (byte b in md5HashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }
            }
            md5Password = sb.ToString();

        }




    }
}
