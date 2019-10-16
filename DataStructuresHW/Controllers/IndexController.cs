using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresBasics.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public static Queue<string> qMyQueue = new Queue<string>();

        //Create dictionary 
        public static Dictionary<string, int> myDict = new Dictionary<string, int>();

        public ActionResult Index()
        {  
            //Declare length of queue
            int queuelength = 100;

            //For loop to load up the queue with random names
            for (int iCount = 0; iCount < queuelength; iCount++)
            {
                string newName = IndexController.randomName();
                qMyQueue.Enqueue(newName);
            }

            //For loop to load dictionary with keys and values
            for (int iCount = 0; iCount < queuelength; iCount++)
            {
                //If statement to see if Key name has already been entered in dictionary, concatenate value using randomnumber
                if (myDict.ContainsKey(qMyQueue.Peek()))
                {
                    myDict[qMyQueue.Dequeue()] += randomNumberInRange();
                }
                //If key name is not in dictionary yet, add it and assign value random number
                else
                {
                    myDict.Add(qMyQueue.Dequeue(), randomNumberInRange());
                }
            }

            //Use Linq to sort the dictionary descending and add it to var items
            var items = from pair in myDict
                        orderby pair.Value descending
                        select pair;
            
            //Create html table output
            string output = "";
            output = "<table align='right' style='width:40%'>";
            output += "<th width='50%'>Customer</th>";
            output += "<th width='50%'>Burger Total</th>";

            //Grab each key and value in items(sorted dictionary) and add it in table
            foreach (KeyValuePair<string, int> entry in items)
            {
                output += "<tr>";
                output += "<td>" + entry.Key + "</td>";
                output += "<td>" + entry.Value + "</td>";
                output += "</tr>";

            }

            //add output to Viewbag
            ViewBag.Output = output;
            
            return View();
        }
        
        
        public static Random random = new Random();

        //generate randomname method
        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];

        }
        
        //generate random number method
        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }

    }
}