//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using AtherMesRestApi.MESModels;
//using AtherMesRestApi.DtoModels;

//namespace AtherMesRestApi.Controllers
//{
//    [Route("api/saporderservice")]
//    [ApiController]
//    public class SapOrdersController : ControllerBase
//    {
//        private readonly MESDBContext _context;

//        public SapOrdersController(MESDBContext context)
//        {
//            _context = context;
//        }

//        //// GET: api/SapOrders
//        //[HttpGet]
//        //public async Task<ActionResult<IEnumerable<SapOrder>>> GetSapOrders()
//        //{
//        //    return await _context.SapOrders.ToListAsync();
//        //}

//        //// GET: api/SapOrders/5
//        //[HttpGet("{id}")]
//        //public async Task<ActionResult<SapOrder>> GetSapOrder(string id)
//        //{
//        //    var sapOrder = await _context.SapOrders.FindAsync(id);

//        //    if (sapOrder == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return sapOrder;
//        //}



//        // POST: api/SapOrders
//        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost("addOrders")]
//        public async Task<StandardResponseProductionOrder_Dto> PostSapOrder(NewSapProductionOrderDto NewOrdersFromSap)
//        {

//            List< StandardResponseProductionOrder> resp = new List<StandardResponseProductionOrder>();

//            foreach (var po in NewOrdersFromSap.MesProductionOrders)
//            {
//                List<SapProductionKeyComponents> sapProductionKeyComponents = new List<SapProductionKeyComponents>();
//                ///static Production date will be sent from the SAP
//                ///static Production shift will be sent from the SAP

//                //Validations to come here

//                if (SapOrderExists(po.Production_Order_No))
//                {
//                    resp.Add(new StandardResponseProductionOrder()
//                    {
//                        Production_Order_No = po.Production_Order_No,
//                        MessageType = "F",
//                        Message = "Duplicate Production Order No."
//                    }
//                    );

//                    continue;
//                }

//                //


//                SapProductionOrder sapOrder = new SapProductionOrder()
//                {
//                    Production_Order_No = po.Production_Order_No,
//                    SKU = po.SKU,
//                    SKU_Description = po.SKU_Description,
//                    Prod_Date = po.Prod_Date,
//                    Prod_Shift = po.Prod_Shift,
//                    Line_No = po.Line_No,
//                    Order_Quantity = po.Order_Quantity,
//                    Cell_Type = po.Cell_Type,
//                    UOM = po.UOM,
//                    Serial_No = po.Serial_No,
//                    Status = 1
//                };

//                foreach (var kc in po.KeyComponents)
//                {
//                    sapProductionKeyComponents.Add(new SapProductionKeyComponents()
//                    {
//                        Production_Order_Key_Component_Key = po.Production_Order_No + "_" + kc.Key_Component,
//                        Production_Order_No = po.Production_Order_No,
//                        Key_Component = kc.Key_Component,
//                        Key_Component_Description = kc.Key_Component_Description,
//                        Key_Component_Type = kc.Key_Component_Type


//                    });

//                }


//                _context.SapProductionOrder.Add(sapOrder);
//                _context.SapProductionKeyComponents.AddRange(sapProductionKeyComponents);

//                resp.Add(new StandardResponseProductionOrder()
//                {
//                    Production_Order_No = po.Production_Order_No,
//                    MessageType = "S",
//                    Message = "Success"
//                }
//               );
//            }

//            try
//            {
//                await _context.SaveChangesAsync();

//            }
//            catch (DbUpdateException e)
//            {
//                resp.Add(new StandardResponseProductionOrder()
//                {
//                    Production_Order_No = "NA",
//                    MessageType = "F",
//                    Message = e.Message.ToString()
//                }
//                );

//                return new StandardResponseProductionOrder_Dto() { Response= resp };
//            }

//            return new StandardResponseProductionOrder_Dto() { Response = resp };
//        }


//        private bool SapOrderExists(string id)
//        {
//            return _context.SapProductionOrder.Any(e => e.Production_Order_No == id);
//        }
//    }
//}
