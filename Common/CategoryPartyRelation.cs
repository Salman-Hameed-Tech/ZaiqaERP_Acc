using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Common
{
    public class CategoryPartyRelation
    {
        public Int32 PartyID { get; set; }
        public string PartyName { get; set; }
        public Int32 MCategoryID { get; set; }
        public string MCategoryName { get; set; }
        //public Int32 SrNo { get; set; }
        //public bool Deleted { get; set; }

        public CategoryPartyRelation() { }
        public CategoryPartyRelation(Int32 partyid, string partyname, Int32 mcid, string mcname) { this.PartyID = partyid; this.PartyName = partyname; this.MCategoryID = mcid; this.MCategoryName = mcname; }
        //public CategoryPartyRelation(Int32 partyid, string partyname, Int32 mcid, string mcname, Int32 srno) { this.PartyID = partyid; this.PartyName = partyname; this.MCategoryID = mcid; this.MCategoryName = mcname; this.SrNo = srno; }
        //public CategoryPartyRelation(Int32 partyid, string partyname, Int32 mcid, string mcname, Int32 srno,bool deleted) { this.PartyID = partyid; this.PartyName = partyname; this.MCategoryID = mcid; this.MCategoryName = mcname; this.SrNo = srno;this.Deleted=deleted; }




    }
}
