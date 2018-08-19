var customerModel = {

    // jquery selectors
    CustomerDelete: "#customers .js-delete",


    // URLs
    CustomerAPIDeleteUrl: "/api/customers/",



    DeleteCustomer: function ( customerID, ItemRow, dataTable) {

        $.ajax({

            url: customerModel.CustomerAPIDeleteUrl + customerID,
            type: "DELETE",
            success: function () {
                // Delete the row from the internal list maintained by DataTables
                dataTable.row(ItemRow).remove().draw();
                //$(ItemRow).remove();
            }
            });
    }
}