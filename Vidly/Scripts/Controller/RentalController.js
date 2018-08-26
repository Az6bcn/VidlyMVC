$(function () {

    var viewModel = {
        MovieIDs: []
    };

    $(document).ready(function () {


        var customers = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                url: rentalModel.customerAPI_URL,
                wildcard: '%QUERY'
            }
        });

        $('#customer').typeahead({ minLength: 3, highlight: true }, {
            name: 'customers',
            display: 'Name',
            source: customers
        }).on("typeahead:select", function (e, customer) {
            //add the select custormer to the viewModel object
            viewModel.customerId = customer.ID
        });





        var movies = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                url: rentalModel.movieAPI_URL,
                wildcard: '%QUERY'
            }
        });

        $('#movie').typeahead({ minLength: 3, highlight: true }, {
            name: 'movies',
            display: 'Name',
            source: movies
        }).on("typeahead:select", function (e, movie) { // select event typehead
            $("#movies").append("<li class='list-group-item'>" + movie.Name + "</li>");

            // clear textbox after the selection
            /* we can't use the JQuery Val() on the movie textbox to SET the value bcos we have applied the typeahead plug-in on it
                To change the value of the TextBox we need to use the typeahead plug-in 
                    $('movieTextboxID').typeahead('specify property to update', the value)    
            */
            $("#movie").typeahead('val', '');

            // store movie in the viewModel object to send to the server
            viewModel.MovieIDs.push(movie.Id)
        });
    });
    
    /********* CUSTOM VALIDATOR ************/
    $.validator.addMethod("validCustomer", function () {
        // check the customer in the viewModel has an Id
        return viewModel.customerId && viewModel.customerId !== 0;
    }, "Select a valid customer");

   
    $.validator.addMethod("validMovie", function () {
        // check the movieIds array is > 0, means there is at least one movie in the array
        return viewModel.MovieIDs.length > 0;
    }, "Select a valid customer");
    /***********************************/

    // plugs validation into the form
   var validator = $('#newRentalForm').validate({
        // if form is valid, this form is called to submit the form to the server
        submitHandler: function () {
            // send viewModel object to server
            rentalModel.createNewRental(viewModel, validator);


            // prevent the form from been submitted normally (same has e.preventDefault();) but we dont have refrence to e but the form.  
            return false;
        }
    })



    //$('#newRentalForm').submit(function (e) {
        
    //})
})