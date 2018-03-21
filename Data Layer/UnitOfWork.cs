
using DataLayer.Interfaces;
using DataLayer.Repositories;
using System;
using System.IO;


namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        
        public NorthWindContext _context;
        public IOrderRepository Orders { get; set; }
        public IOrderDetailsRepository OrderDetails { get; set; }
        public IProductRepository Products { get; set; }
        public ICategoryRepository Categories { get; set; }


        /// <summary> Instantiate a EfContext and then use it across all repositories.  </summary>
        /// <param name="context"> </param>  
        public UnitOfWork(NorthWindContext context)    //ToDo: dependency injection service
        {
            _context = context;
            Orders = new OrderRepository(_context);
            OrderDetails = new OrderDetailsRepository(_context);
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
        }


        /// <summary> Commit the changes </summary>    
        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                return -1;
            }

        }


        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }



        /// <summary> Log an error which occurred within the data source layer </summary>
        /// <param name="ex"> the exception which occurred </param>
        internal static void WriteErrorLog(Exception ex)
        {           
            string errorLogFilename = "ErrorLog.txt";
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + errorLogFilename;   //core replacement for Server.MapPath("~/" + errorLogFilename)
                if (File.Exists(path))
                {
                    using (StreamWriter stwriter = new StreamWriter(path, true))
                    {
                        stwriter.WriteLine("-------------------Error Log Start----------- on " + DateTime.Now.ToString("hh:mm tt"));
                        stwriter.WriteLine("Message:  " + ex.Message);
                        stwriter.WriteLine("Stack trace:  " + ex.StackTrace);
                        stwriter.WriteLine("-------------------End----------------------------");
                    }
                }
                else
                {
                    StreamWriter stwriter = File.CreateText(path);
                    stwriter.WriteLine("-------------------Error Log Start----------- on " + DateTime.Now.ToString("hh:mm tt"));
                    stwriter.WriteLine("Message:  " + ex.Message);
                    stwriter.WriteLine("Stack trace:  " + ex.StackTrace);
                    stwriter.WriteLine("-------------------End----------------------------");
                    stwriter.Close();
                }
            }
            catch (Exception)
            {
                // prevent stopping
            }         
        }


    }
}

