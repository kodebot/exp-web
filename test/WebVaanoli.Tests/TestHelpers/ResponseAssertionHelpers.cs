using Microsoft.AspNet.Mvc;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebVaanoli.Tests.TestHelpers
{
    public static class ResponseAssertionHelpers
    {
        public static void ShouldBeHttpBadRequest(this IActionResult actionResult)
        {
            actionResult.ShouldBeAssignableTo(typeof(BadRequestResult));
        }

        public static void ShouldBeHttpNotFound(this IActionResult actionResult)
        {
            actionResult.ShouldBeAssignableTo(typeof(HttpNotFoundResult));
        }

        public static void ShouldBeDefaultView(this IActionResult actionResult)
        {
            actionResult.ShouldBeAssignableTo(typeof(ViewResult));

            var viewResult = actionResult as ViewResult;
            viewResult.ViewName.ShouldBeNull(); // indicates default view
        }

        public static void ShouldBeViewResultWithModel<T>(this IActionResult actionResult, string viewName = null) where T : class
        {
            actionResult.ShouldBeAssignableTo(typeof(ViewResult));

            var viewResult = actionResult as ViewResult;
            viewResult.ViewName.ShouldBe(viewName);

            var model = viewResult.ViewData.Model as T;
            model.ShouldNotBeNull();

        }

        public static void ShouldBeViewResultWithViewName(this IActionResult actionResult, string viewName = null)
        {
            actionResult.ShouldBeAssignableTo(typeof(ViewResult));

            var viewResult = actionResult as ViewResult;
            viewResult.ViewName.ShouldBe(viewName);
        }

        public static void ShouldBeViewResultWithModelSatisfyingAllConditions<T>(this IActionResult actionResult, string viewName = null, params Action<T>[] actions) where T : class
        {
            actionResult.ShouldBeAssignableTo(typeof(ViewResult));
            var viewResult = actionResult as ViewResult;

            viewResult.ViewName.ShouldBe(viewName);

            var model = viewResult.ViewData.Model as T;
            model.ShouldNotBeNull();
            model.ShouldSatisfyAllConditions(actions.Select(act => new Action(() => act.Invoke(model))).ToArray());
        }
    }
}
