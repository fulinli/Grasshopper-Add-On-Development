using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace RuleBaseBlock
{
    public class RuleBaseBlockInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "RuleBaseBlock";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("b2757a56-a388-4fde-8454-b88868af6c1e");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
