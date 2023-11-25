namespace AtherMesRestApi.MESModels
{
    public class FGResponse
    {
        public string BMS { get; set; }
        public string PCBA { get; set; }
        public string BMSRevision { get; set; }
        public string PCBARevision { get; set; }
        public int? Status { get; set; }
        public string? Line { get; set; }
        public int? PlanID { get; set; }

        public FGResponse(string bMS, string pCBA, string bMSRevision, string pCBARevision, int? status, string line, int planID)
        {
            BMS = bMS;
            PCBA = pCBA;
            BMSRevision = bMSRevision;
            PCBARevision = pCBARevision;
            Status = status;
            Line = line;
            PlanID = planID;
        }

        public FGResponse()
        {
        }


    }
}
