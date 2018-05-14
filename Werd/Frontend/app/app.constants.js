(function() {

    "use strict";

    angular
        .module("app")
        .constant("apiUrl", "http://localhost:8088/api/")
        .constant("dataUrl", "http://localhost:8088/Data/");
})();