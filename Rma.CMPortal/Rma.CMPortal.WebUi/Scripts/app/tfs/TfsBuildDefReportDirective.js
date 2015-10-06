(function() {
	'use strict';

	window.app.directive('tfsBuildDefReport', tfsBuildDefReport);

	function tfsBuildDefReport() {
		return {
			scope: true,
			templateUrl: '/tfs/template/tfsBuildDefReport.tmpl.cshtml',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$http'];
	function controller($http) {
		var vm = this;

		vm.isLoading = true;

	    $http.post('/Tfs/TFSBuildDef')
			.success(function (customers) {
				vm.customers = customers;
				vm.isLoading = false;
			});
	}
})();