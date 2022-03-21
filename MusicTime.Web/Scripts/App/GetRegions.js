$('#btnClick').click(function () {
  alert("Hello world");

})

$('#Country').change(function () {
  var selectedCountry = $('#Country').val();
  var regionsSelect = $('#Region');
  var countryIndex = $('#Country option:selected').index();
  regionsSelect.empty();
  if (selectedCountry != null && $("#Country option:selected").index() != 0) {

    $.ajax({
      url: "/Customer/GetRegions",
      data: {countryCode: selectedCountry}, //this could also be form data
      contentType: "application/json",
      success: function (result) {
        var ddlAppendData = '';
        if (result != null) {
          $.each(result, function (i, region) {
            ddlAppendData += '<option value="' + region.Value + '">' + region.Text + "</option>";
          });
          regionsSelect.append(ddlAppendData);
        }
        
      }
    });


    console.log('TRUE');
  }
  else {
    console.log('FALSE');
  }
  var value = $('#Country option:selected');
  console.log('Selected Country:' + selectedCountry + ', ' + 'Selected Dropdown Text: ' + value.text() + ', Country Index: ' + countryIndex);
})

function postSuccess() {
  alert('post success from getregions');
}
