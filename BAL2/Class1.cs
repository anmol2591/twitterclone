using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary2;

namespace BAL
{
    public class MyHandler
    {
        public List<Tweet> getTweet(string userid)
        {
            Class1 c = new Class1();
            var data = c.Display(userid);
            List<Tweet> t = new List<Tweet>();
            foreach (var item in data)
            {
                Tweet twt = new Tweet();
                twt.tweet_id = item.tweet_id;
                twt.message = item.message;
                twt.created = (DateTime)item.created;
                twt.user_id = item.user_id;
                t.Add(twt);
            }
            return t;
        }
        public List<Tweet> DisplayTweets(string userid)
        {
            Class1 c = new Class1();
            var data = c.Displaytweets(userid);
            List<Tweet> t = new List<Tweet>();
            foreach (var item in data)
            {
                Tweet twt = new Tweet();
                twt.tweet_id = item.tweet_id;
                twt.message = item.message;
                twt.created = (DateTime)item.created;
                twt.user_id = item.user_id;
                t.Add(twt);
            }
            var newdata = c.Display(userid);
            foreach (var item in newdata)
            {
                Tweet twt = new Tweet();
                twt.tweet_id = item.tweet_id;
                twt.message = item.message;
                twt.created = (DateTime)item.created;
                twt.user_id = item.user_id;
                t.Add(twt);
            }
            return t;
        }

        public List<Person> users(string uid)
        {
            Class1 c = new Class1();
            var data = c.users(uid);
            List<Person> p = new List<Person>();
            foreach (var item in data)
            {
                Person per = new Person();
                per.fullName = item.fullName;
                per.fullName = item.fullName;
                per.active = item.active;
                per.email = item.email;
                per.user_id = item.user_id;
                p.Add(per);
            }
            return p;
        }

        public List<Person> search(string name, string uid)
        {
            Class1 c = new Class1();

            //ICollection<Person> p = c.search(name) as ICollection<BLayer.Person>;
            var data = c.search(name, uid);
            List<Person> p = new List<Person>();
            foreach (var item in data)
            {
                Person per = new Person();
                per.fullName = item.fullName;
                per.active = item.active;
                per.email = item.email;
                per.user_id = item.user_id;
                p.Add(per);
            }
            return p;
        }
        public List<Person> following(string uid)
        {
            Class1 c = new Class1();
            var data = c.following(uid);
            List<Person> foll = new List<Person>();
            foreach (var item in data)
            {
                Person f = new Person();
                f.fullName = item.fullName;
                f.user_id = item.user_id;
                f.email = item.email;
                foll.Add(f);
            }
            return foll;


        }
        public List<Person> follower(string uid)
        {
            Class1 c = new Class1();
            var data = c.followers(uid);
            List<Person> foll = new List<Person>();
            foreach (var item in data)
            {
                Person f = new Person();
                f.user_id = item.user_id;
                f.fullName = item.fullName;
                f.email = item.email;
                foll.Add(f);
            }
            return foll;

        }

        public Person login(string ema, string pass)
        {
            Class1 c = new Class1();

            //ICollection<Person> p = c.search(name) as ICollection<BLayer.Person>;
            var data = c.login(ema, pass);



            Person per = new Person();
            per.fullName = data.fullName;
            per.active = data.active;
            per.email = data.email;
            per.user_id = data.user_id;
            per.active = data.active;
            per.joined = data.joined;


            return per;
        }
        public void CreateUser(string Fname, string uid, string pass, string email, DateTime join, bool status)
        {
            Class1 c = new Class1();
            c.CreateUser(Fname, uid, pass, email, join, status);
        }
        //public void forpass(string email)
        //{
        //    Class1 c = new Class1();
        //    c.forpass(email);
        //}
        public void UpdateProfile(string uid, string Fname, string pass)
        {
            Class1 c = new Class1();
            c.UpdateProfile(uid, Fname, pass);
        }
        public void DeleteProfile(string uid)
        {
            Class1 c = new Class1();
            c.DeleteProfile(uid);
        }

        public void Follow(string uid, string followid)
        {
            Class1 c = new Class1();
            c.Follow(uid, followid);
        }
        public void UnFollow(string uid, string followid)
        {
            Class1 c = new Class1();
            c.UnFollow(uid, followid);
        }
        public void check(string uid, string followid, out bool chck)
        {
            bool chk;
            Class1 c = new Class1();
            c.check(uid, followid, out chk);
            chck = chk;
        }
        public void count(string uid, out int tno, out int fno, out int flno, out int img)
        {
            int a, b, aa, bb;
            Class1 c = new Class1();
            c.count(uid, out a, out b, out aa, out bb);
            tno = a;
            fno = b;
            flno = aa;
            img = bb;
        }
        public void AddTweet(string uid, string message, DateTime dt, out int id)
        {
            int id1;
            Class1 c = new Class1();
            c.AddTweet(uid, message, dt, out id1);
            id = id1;
        }
        public void DelTweet(int uid)
        {
            Class1 c = new Class1();
            c.DelTweet(uid);
        }
        public void UpdTweet(int uid, string message)
        {
            Class1 c = new Class1();
            c.UpdTweet(uid, message);
        }
        public void imag(string uid)
        {
            Class1 c = new Class1();
            c.imag(uid);
        }
        public int CheckUser(string uid, string followid)
        {
            int chk;
            Class1 c = new Class1();
            chk = c.checkUser(uid, followid);
            return chk;
        }
    }

    public class Person
    {
        public string user_id { get; set; }
        // public string password;
        public string fullName { get; set; }
        public string email { get; set; }
        public DateTime joined { get; set; }
        // public string joined;
        public bool active { get; set; }
        private List<Tweet> t;
        private List<Person> foll;




    }

    public class Tweet
    {
        public int tweet_id { get; set; }
        public string user_id { get; set; }
        public string message { get; set; }
        public DateTime created { get; set; }


    }
    public class following
    {
        public string user_id { get; set; }
        public string followingid { get; set; }
    }
}
