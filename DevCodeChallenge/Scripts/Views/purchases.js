$(document).ready(function () {
    const filterTotalCostGreaterThan = 1000;

    function refreshTable(iconElement) {
        var sortIcon = $('.sort-icon i');
        var isAscending = sortIcon.hasClass('fa-sort-up');

        $.ajax({
            url: '/Purchase/GetPurchasesJson?ascendingOrder=' + isAscending,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                updateTable(data);
                toggleSortingOrder(sortIcon);
            },
            error: function () {
                console.log('Error fetching data');
            }
        });
    }

    function updateTable(data) {
        var tableBody = $('#purchaseTableBody');
        tableBody.empty();

        $.each(data, function (index, item) {
            var row = '<tr>' +
                '<td>' + item.Id + '</td>' +
                '<td>' + item.Quantity + '</td>' +
                '<td>' + item.TotalCost + '</td>' +
                '<td>' + item.Date + '</td>' +
                '</tr>';

            tableBody.append(row);
        });
    }

    function toggleSortingOrder(iconElement) {
        // Toggle the class based on the current sorting order
        if (iconElement.hasClass('fa-sort-up')) {
            iconElement.removeClass('fa-sort-up');
            iconElement.addClass('fa-sort-down');
        } else {
            iconElement.removeClass('fa-sort-down');
            iconElement.addClass('fa-sort-up');
        }
    }

    // Sort table
    $('.sort-icon').click(function () {
        refreshTable($(this).find('i'));
    });

    // Filter greter than 1000
    $('#filterButton').click(function () {
        $.ajax({
            url: `/Purchase/GetPurchasesWithTotalCostGreaterThanJson?totalCost=${filterTotalCostGreaterThan}`,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                updateTable(data);
            },
            error: function () {
                console.log('Error fetching filtered data');
            }
        });
    });
});
