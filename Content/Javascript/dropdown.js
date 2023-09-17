$(document).ready(function () {
    var stateDropdown = $("#stateDropdown");
    var cityDropdown = $("#cityDropdown");

    var citiesByState = {
        "State1": ["CityA", "CityB", "CityC"],
        "State2": ["CityD", "CityE", "CityF"],
        
    };

    stateDropdown.change(function () {
        var selectedState = stateDropdown.val();
        var cities = citiesByState[selectedState] || [];

        cityDropdown.empty();
        $.each(cities, function (i, city) {
            cityDropdown.append($('<option>', {
                value: city,
                text: city 
            }));
        });
    });
});
