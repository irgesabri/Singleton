using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
            Console.Read();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        //aynı anda iki kullanıcı istekte bulunursa.
        static object _lockObject = new object();
        private CustomerManager()
        {
            //amacımız dış erişimi engellemektir.

        }
        public static CustomerManager CreateAsSingleton()
        {
            //aynı anda iki kullanıcı bu nesneyi almak isterse ben onu diğer kullanıcının işi bitene kadar kilitliyorum. 
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
                return _customerManager;
            }

           // return _customerManager ?? (_customerManager = new CustomerManager()); 
            //if (_customerManager==null)
            //{
            //    _customerManager = new CustomerManager();
            //}
            //return _customerManager;
        }

        public  void Save()
        {
            Console.WriteLine("Save Method");
        }
    }
}
