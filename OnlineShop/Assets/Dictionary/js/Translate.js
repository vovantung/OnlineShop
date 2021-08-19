var trans = {
    init: function () {
        trans.translate();
    },
    translate: function () {
        $(".translate").on("change", function () {
            var tow = $(".toword");
            var text = $(this);
            var word = text.val();
            $.ajax({
                url: "/Example/Translation",
                data: { word: word },
                type: "POST",
                dataType: "json",
                success: function (response) {
                 
                    tow.val(response.toword_trans);
                }

            });

        });
    }
}
trans.init();