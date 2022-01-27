$('#btnClick').click(function () {
  alert("Hello world");

})

$('#Country').change(function () {
  var selectedCountry = $('#Country').val();
  var regionsSelect = $('#Region');
  var countryIndex = $('#Country option:selected').index();
  regionsSelect.empty();
  if (selectedCountry != null && $("#Country option:selected").index() != 0) {
    console.log('If Statement');
    $.getJSON('GetRegions'), { isoCode: selectedCountry }, function (regions) {
      if (regions != null && !jQuery.isEmptyObject(regions))
      {
        regionsSelect.append($('<option/>', {
          value: null,
          text: ""
        }));
        $.each(regions, function (i, region) {
          regionsSelect.append($('<option/>', {
            value: region.Value,
            text: region.Text
          }))
        })
      }
    }
    console.log('TRUE');
  }
  else {
    console.log('FALSE');
  }
  var value = $('#Country option:selected');
  console.log('Selected Country:' + selectedCountry + ', ' + 'Selected Dropdown Text: ' + value.text() + ', Country Index: ' + countryIndex);
})
