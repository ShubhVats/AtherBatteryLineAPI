﻿using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Quality_DHCRejection_WIPCommon
    {
        public Quality_DHCRejection_WIPCommon(string parameterId, string parameterVal, string bIN_Number, int stationId, string category, string subCategory, string operatorRemark, string bUGId, string qIRemarks, string rSARemark, int partChangeFlag, int sKUChangeFlag, string reworkRemark, int lineId, int status, string reworkStationName, int saveFlag)
        {
            ParameterId = parameterId;
            ParameterVal = parameterVal;
            BIN_Number = bIN_Number;
            StationId = stationId;
            Category = category;
            SubCategory = subCategory;
            OperatorRemark = operatorRemark;
            BUGId = bUGId;
            QIRemarks = qIRemarks;
            RSARemark = rSARemark;
            PartChangeFlag = partChangeFlag;
            SKUChangeFlag = sKUChangeFlag;
            ReworkRemark = reworkRemark;
            LineId = lineId;
            Status = status;
            ReworkStationName = reworkStationName;
            SaveFlag = saveFlag;
        }
        [Key]
        public int RowId { get; set; }
        public string ParameterId { get; set; }
        public string ParameterVal { get; set; }
        public string BIN_Number { get; set; }
        public int StationId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string OperatorRemark { get; set; }
        public string BUGId { get; set; }
        public string QIRemarks { get; set; }
        public string RSARemark { get; set; }
        public int PartChangeFlag { get; set; }
        public int SKUChangeFlag { get; set; }
        public string ReworkRemark { get; set; }
        public int LineId { get; set; }
        public int Status { get; set; }
        public string ReworkStationName { get; set; }
        public int SaveFlag { get; set; }

    }
}
