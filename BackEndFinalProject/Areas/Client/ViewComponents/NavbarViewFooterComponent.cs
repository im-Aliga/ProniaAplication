using BackEndFinalProject.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BackEndFinalProject.Areas.Admin.ViewComponents
{
    //[ViewComponent(Name = "NavbarFooter")]
    //public class NavbarViewFooterComponent : ViewComponent
    //{
    //    private readonly DataContext _datacontext;
    //    public NavbarViewFooterComponent(DataContext dataContext)
    //    {
    //        _datacontext = dataContext;
    //    }

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {
    //        var model = _datacontext.Navbars.Include(n => n.SubNavbars.OrderBy(sn => sn.RowNumber)).Where(n => n.IsShowFooter).OrderBy(n => n.RowNumber).ToList();

    //        return View( model);
    //    }
    //}
}
