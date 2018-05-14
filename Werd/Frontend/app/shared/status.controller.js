(function() {

    "use strict";

    angular
        .module("app")
        .controller("StatusController",
        [
            "$q",
            "$sce",
            "$scope",
            "$http",
            "apiUrl",
            "dataUrl",
            statusController
        ]);

    function statusController($q, $sce, $scope, $http, apiUrl, dataUrl) {
        var vm = this;

        vm.xmlSchemaView = null;

        vm.returnStatus = {
            0: $sce.trustAsHtml("<span class=\"text-success\">Accepted</span>"),
            1: $sce.trustAsHtml("<span class=\"text-danger\">Rejected</span>"),
            2: $sce.trustAsHtml("<span class=\"text-primary\">Ready to Release</span>"),
            3: $sce.trustAsHtml("<span class=\"text-info\">CCH Review</span>"),
            4: $sce.trustAsHtml("<span class=\"text-warning\">Schema Validation Error</span>")
        };

        $scope.getXmlSchema = function(id) {
            if (id) {
                $http.get(apiUrl + "xml/" + id)
                    .then(function(response) {
                        vm.xmlSchemaView = response.data;
                    });
            }
        };
        $scope.downloadXmlSchema = function(id) {
            var file = id + ".xml";
            var path = dataUrl + file;
            $http.get(path,
                {
                    responseType: "arraybuffer"
                })
                .then(function(response) {
                    $scope.filedata = response.data;
                    var headers = response.headers();
                    headers["Content-Disposition"] = "attachment";
                    var blob = new Blob([response.data], { type: "octet/stream" });
                    var link = document.createElement("a");
                    link.href = window.URL.createObjectURL(blob);
                    link.download = file;
                    document.body.appendChild(link);
                    link.click();
                    document.body.removeChild(link);
                });
        };

        $scope.filterResults = function() {
            var f = $scope.filter;
            vm.filteredReturns = vm.returns;
            if (f.taxYear) {
                vm.filteredReturns = vm.filteredReturns.filter(function(r) {
                    return r.taxYear.toString() === f.taxYear;
                });
            }
            if (f.product) {
                vm.filteredReturns = vm.filteredReturns.filter(function (r) {
                    return r.product.toString() === f.product;
                });
            }
            if (f.statusId) {
                vm.filteredReturns = vm.filteredReturns.filter(function (r) {
                    if (f.entity === "federal") {
                        return r.federalStatus.toString() === f.statusId;
                    }
                    if (f.entity === "state") {
                        return r.stateStatus.toString() === f.statusId;
                    }
                });
            }
            if (f.preparerId) {
                vm.filteredReturns = vm.filteredReturns.filter(function (r) {
                    return r.preparer.id.toString() === f.preparerId;
                });
            }
        }

        $scope.clearResults = function() {
            $scope.filter = {}
            $scope.filter.entity = "federal";
            vm.filteredReturns = vm.returns;
        }

        $http.get(apiUrl + "returns")
            .then(function(response) {
                vm.returns = response.data;
                $scope.clearResults();
            }, function(response) {
                console.log(response);
            });
        
        $http.get(apiUrl + "users")
            .then(function(response) {
                vm.users = response.data;
            }, function(response) {
                console.log(response);
            });
    }
})();