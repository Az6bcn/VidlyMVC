var rentalModel = {

    // twitter.typeahead autocomplete, what uses type will be = QUERY to filter and return those who match the query
    customerAPI_URL: "/api/Customers?query=%QUERY",
    movieAPI_URL: "/api/movies/GetMovies?query=%QUERY",
    createNewRentalURL: '/api/NewRental',

    createNewRental: function(viewModel, validator) {
        $.ajax({
            url: rentalModel.createNewRentalURL,
            method: 'POST',
            data: viewModel
        })
        .done(function (data) {
            toastr.success("Rentals successful recorded");
            // clear the textboxes
            $('#customer').typeahead("val", "");
            $('#movie').typeahead("val", "");
            //empty the list
            $('#movies').empty();
            //reset form in terms of validator
            validator.resetForm();
        })
        .fail(function () {

            toastr.warning("something unexpected happened");
        });

    }
}