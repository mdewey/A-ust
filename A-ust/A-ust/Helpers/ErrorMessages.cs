using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A_ust.Helpers
{
    public static class ErrorMessages
    {
        //Projects
        public static string ErrorAddingProject = "Error adding, See inner exceptions";
        public static string ProjectWasNotFound = "Porject was not found";
        public static string ErrorUpdatingProject = "Error updated project, see inner exceptions";
        public static string ErrorDeletingProject = "Error deleting project, see inner exceptions";

        //Assumptions
        public static string ErrorDeletingAssumptions = "Error Deleting a assumption, see inner exception for details";
        public static string ErrorUpdatingAssumptions = "Error updating a assumption, see inner exception for details";
        public static string ErrorAddingAssumptions = "Error adding a assumption, see inner exception for details";
        public static string AssumptionWasNotFound = "Assumptions was not found";
    }
}