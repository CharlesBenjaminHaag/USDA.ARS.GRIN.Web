/* ==========================================================================================
 * File         : Search.js 
 * Description  : Scripts used across all search pages.
 * ============================================================================================
 */

$('#frmSearch').on('submit', function (evt) {
    evt.preventDefault();

    $.post('Search', $(this).serialize(), function (response) {
        $('#search-results-container').html(response); // assuming response is HTML
    });
});

$(document).ajaxStart(function () {
    $("#wait").css("display", "block");
});

$(document).ajaxComplete(function () {

    var resultsFound = 0;

    $("#wait").css("display", "none");

    // If no results were found, ensure that Excel-export option is not visible.
    resultsFound = $("#hfResultsFound").val();
    if (resultsFound > 0) {
        $("#left-nav-search-results-options").show();
    }
    else {
        $("#left-nav-search-results-options").css("display", "none");
    }
});