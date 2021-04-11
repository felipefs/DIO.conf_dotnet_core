using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Models;

namespace WebApi.Filters
{
    public class ValidacaoModelStateCustomizado : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext context)
      {
          
            if(!context.ModelState.IsValid){
                var validaCompoViewModel = new ValidaCampoViewModelOutput(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s=> s.ErrorMessage));
                context.Result = new BadRequestObjectResult(validaCompoViewModel);
                
            }
         
      }

    }
}