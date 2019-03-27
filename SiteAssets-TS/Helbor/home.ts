/// <reference path="../../typings/index.d.ts" />

(($: JQueryStatic) => {
  $(() => {

    CS.Components.RevolutionSlider({
      renditionId: 5,
      defaultVideoWidth: 1920,
      defaultVideoheight: 370,
      slider: {
        delay: 1500,
        startwidth: 1920,
        startheight: 370,
        gridwidth: 1920,
        gridheight: 370
      }
    });

    CS.Components.Birthdays({
      link: `../SitePages/Birthdays.aspx`,
      fromDay1: true,
      sendMessageIcon: '../SiteAssets/images/send-birthday-message.png',
      transitionEffect: true,
      bxSlider: {
        minSlides: 4,
        maxSlides: 4
      },
      mobileBxSlider: {
        minSlides: 2,
        maxSlides: 2
      },
      sendMethod: 'input'
    });

    CS.Components.News.All({
      container: "#news-container",
      fullpage: false,
      componentHeader: "normal",
      scrollContainer: "#page-items",
      packeryColumns: 3,
      blockHeight: 196,
      renditions: {
        'pequeno': 8,
        'longo-horizontal': 9,
        'longo-vertical': 10,
        'grande': 11
      }
    });

    $('#csu-news-header').prepend('<span id="news-icon" class="csu-news-icon"></span>');

    CS.Components.Calendar({
      iconLogoContainer: null,
      popupIconClass: null
    });

    //Search
    let searchInterval = setInterval(
      () => {
        if ($("#csu-revolution-slider-list > li > div.slotholder > div").length && $("#search-lupa").val() == undefined) {
          let search = `<div id="search-containner">
                                    <div id="search-wrapper">
                                        <input id="search-box" type="text" placeholder="O que procura?" autocomplete="off"/>
                                        <span id="search-lupa"></span>
                                    </div>
                                </div>`;
          $("#revolution-slider-container").prepend(search);
          $("#search-lupa").on("click", () => {
            if (searchInput.val() != "") {
              goToSearchPage(searchInput.val());
            }
          });
          let searchInput = $("#search-box");
          searchInput.keypress(function (e) {
            if (e.which == 13 && searchInput.val() != "") {
              e.preventDefault();
              goToSearchPage(searchInput.val());
            };
          });
          clearInterval(searchInterval);
        }
      }, 500);

    let goToSearchPage = (query) => {
      let site = _spPageContextInfo.webAbsoluteUrl;
      let pagBusca = "/SitePages/Tudo.aspx?k=";
      location.href = site + pagBusca + query;
    };
  });
})(jQuery);