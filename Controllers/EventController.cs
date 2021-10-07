using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModifyXml.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Aventra_task\conf - examples.xml");
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            return Ok(jsonText);
        }

        [HttpPost]
        public IActionResult Post(int Id, string TypeName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Aventra_task\conf - examples.xml");
            XmlNode root = doc.SelectSingleNode("ActiveCMSMonitor");
            XmlElement firstMonitorEvent = doc.CreateElement("MonitorEvent");
            root.AppendChild(firstMonitorEvent);
            XmlAttribute xsiType = doc.CreateAttribute("TypeName");
            xsiType.Value = "DatabaseAction";
            //firstMonitorEvent.Attributes.Append(xsiType);
            string jsonText = JsonConvert.SerializeXmlNode(doc);

            //object myObject = JsonConvert.DeserializeObject(jsonText);
            doc.Save(@"D:\Aventra_task\conf - examples.xml");

            return Content(jsonText);

        }


    }
}
