$(function () {
    var table; 
    $(document).ready(function () {
        // get refrence to customers table skeleton and output it has a datatable
        table = $("#customers").DataTable({
            ajax: {
                url: '/api/Customers',
                dataSrc: ''
            },
            columns: [
                {
                    data: "Name",
                    render: function(data, type, customer) {
                        // return clickable link
                        return "<a href='/customers/edit/" + customer.ID + "'>" + customer.Name + "</a>";
                    }
                },
                {
                    data: "MembershipType.Name"
                },
              
                {
                    data: "ID",
                    render: function(data){
                        return "<button class='btn-link js-delete' data-customer-id=" + data + "> Delete </button>";
                    }
                }

            ]

        });
    })

    //Delete Customer events
    $(document).on('click', customerModel.CustomerDelete, function () {

      
        var cusID = $(this).attr("data-customer-id");
        var row = $(this).parents("tr");

        bootbox.confirm("Are you sure you want to delete the customer?", function (result) {
            
            if (result) {
                customerModel.DeleteCustomer(cusID, row, table);
            }
        });
    })

})