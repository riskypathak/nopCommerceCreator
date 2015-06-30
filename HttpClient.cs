﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace nopCommerceCreator
{
    public class HttpClient : WebClient
    {
        //properties to handle implementing a timeout
        private int? _timeout = null;
        public int? Timeout
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value;
            }
        }

        //A CookieContainer class to house the Cookie once it is contained within one of the Requests
        public static CookieContainer CookieContainer { get; private set; }
        //Constructor
        static HttpClient()
        {
            CookieContainer = new CookieContainer();
        }

        public HttpClient()
        {

        }
        //Method to handle setting the optional timeout (in milliseconds)
        public void SetTimeout(int timeout)
        {
            _timeout = timeout;
        }
        //This handles using and storing the Cookie information as well as managing the Request timeout
        protected override WebRequest GetWebRequest(Uri address)
        {
            //Handles the CookieContainer
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            //Sets the Timeout if it exists
            if (_timeout.HasValue)
            {
                request.Timeout = _timeout.Value;
            }
            return request;
        }
    }
}
