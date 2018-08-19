var movieModel = {
    //  jquery selectors
    movieDelete: "#movies .js-delete",

    //URLs
    movieDeleteURL: "api/movies/DeleteMovie",

    Delete: function (movieID, ItemRow, dataTable) {

        // ajax call to delete movie in DB
        $.ajax({
            url: movieModel.movieDeleteURL+"/"+movieID,
            type: "DELETE",
            success: function () {
                // delete the movie from dataTables internal list
                dataTable.row(ItemRow).remove().draw();
            }
           
        })
    }
}