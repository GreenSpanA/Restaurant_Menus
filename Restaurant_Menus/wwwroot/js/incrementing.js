$(function () {

    $(".numbers-row").append('<div class="inc button">+</div><div class="dec button">-</div>');

    $(".button").on("click", function () {

        var $button = $(this);
        var oldValue = $button.parent().find("input").val();

        if ($button.text() == "+") {
          
            var newVal = parseFloat(oldValue) + 1;

        } else {
            // Don't allow decrementing below zero
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }
        }
        var cur_name = document.getElementById('cur_name').value;

        if (cur_name == "vladimir.davidko@phystech.edu")
        {            

            if (newVal > 5) {
                newVal = 5
            }
        }  
        
        $button.parent().find("input").val(newVal);               
        document.getElementById('pdf_view').data = "PDF/" + newVal.toString() + ".pdf"

    });

});