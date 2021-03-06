﻿using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Text.RegularExpressions;
// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.
namespace RuleBaseBlock
{
    struct Rules
    {
        public string functionname;
        public string parameters;
        public string[] para;
        public int value;
        public int type;
    };
    public class RuleBaseBlockComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public RuleBaseBlockComponent()
          : base("RuleBaseBlock", "Rule",
              "Rule base module",
              "RuleBase", "RuleBaseDemo")
        {
            
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Graphic Infomation Path", "GIP", "Graphic Infomation Path", GH_ParamAccess.item);
            pManager.AddTextParameter("Attribute Information Path", "AIP", "Attribute Infomation Path", GH_ParamAccess.item);
            pManager.AddTextParameter("RuleBase", "RB", "Rule Base", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Result Analysis Report", "RAP", "Result Analysis Report", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string GraPath = "";
            string AttPath = "";
            string RuleBase = "";
            if (!DA.GetData(0, ref GraPath)) { return; }
            if (!DA.GetData(1, ref AttPath)) { return; }
            if (!DA.GetData(2, ref RuleBase)) { return; }
            //正则表达式解析RuleBase中functionname以及参数串parameters
            string Regexsplit = ";";
            string[] arr = Regex.Split(RuleBase, Regexsplit);
            int nums = arr.Length;
            Rules[] ruleset = new Rules[nums];
            for(int i = 0; i < nums; i++)
            {
                ruleset[i].functionname = RuleMatch(arr[i], @"^\w*");
                ruleset[i].parameters = RuleMatch(arr[i], @"\(\S*\)");
                ruleset[i].para = Regex.Split(ruleset[i].parameters, ",");
            }
            //ruleset检查
            for(int i = 0; i < nums; i++)
            {
                switch(ruleset[i].functionname)
                {
                    case "Distance1":
                        //调用Distance1检查函数
                        break;
                    case "Distance2":

                        break;
                }
            }
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("3d8072a8-2a90-4be4-b6e0-868cb9cb9d88"); }
        }

        public string RuleMatch(string text, string expr)
        {
            Match mc = Regex.Match(text, expr);
            string matchresult = mc.ToString();
            int left = matchresult.IndexOf('(');
            int right = matchresult.IndexOf(')');
            if(right>left)
                matchresult = matchresult.Substring(left + 1, right - left - 1);
            return matchresult;
        }
    }
}
