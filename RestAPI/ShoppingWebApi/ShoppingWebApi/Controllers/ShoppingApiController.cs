using Microsoft.AspNetCore.Mvc;
using ShoppingWebApi.EfCore;
using ShoppingWebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingWebApi.Controllers
{
    
    [ApiController]
    public class ShoppingApiController : ControllerBase
    {
        private readonly DbHelper _db;
        public ShoppingApiController(Ef_DataContext ef_DataContext)
        {
            _db=new DbHelper(ef_DataContext);
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("api/[controller]/GetProducts")]
        public IActionResult Get()
        {
            ApiResponseType type= ApiResponseType.Success;
            try
            {
                //retrieving list of the product from the database
                IEnumerable<ProductModel> data=_db.GetProducts();
                if(!data.Any())//checking whether it is empty or not
                {
                    type = ApiResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));

            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
           
        }

        // GET api/<ValuesController>/5
        [HttpGet]
        [Route("api/[controller]/GetProductById/{id}")]

        public IActionResult Get(int id)
        {
            ApiResponseType type = ApiResponseType.Success;
            try
            {
                //retrieving  the product from the database by id
                ProductModel data = _db.GetProductById(id);
                if (data ==null)//checking whether it is empty or not
                {
                    type = ApiResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("api/[controller]/SaveOrder")]
        public IActionResult Post([FromBody] OrderModel model)
        {
            try
            {
                ApiResponseType type=ApiResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetApiResponse(type, model));

            }
            catch(Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateOrder")]

        public IActionResult Put([FromBody] OrderModel model)
        {
            try
            {
                ApiResponseType type = ApiResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetApiResponse(type, model));

            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }


        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [Route("api/[controller]/DeleteOrder/{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                ApiResponseType type = ApiResponseType.Success;
                _db.DeleteOrder(id);
                return Ok(ResponseHandler.GetApiResponse(type, "Delete Successfully!!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
    }
}
