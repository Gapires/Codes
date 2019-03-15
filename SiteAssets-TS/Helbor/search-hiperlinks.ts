/// <reference path="../../typings/index.d.ts" />


(($: JQueryStatic) => {
  $(() => {
    //Faz o filtro por área da página de hiperlinks
    $("#search").on("keyup", function () {
      let value = $(this).val().toLowerCase();
      $('.dfwp-list > li').filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
      });
    });    
  });
})(jQuery);
