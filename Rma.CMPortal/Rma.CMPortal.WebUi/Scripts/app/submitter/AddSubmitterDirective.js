(function() {
	"use strict";

	window.app.directive('addSubmitter', addSubmitter);

	function addSubmitter() {
		return {
		    templateUrl: '/Submitter/template/AddSubmitter.tmpl.cshtml',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$scope', 'submitterSvc'];
	function controller($scope, submitterSvc) {
		var vm = this;
		vm.add = add;

		vm.saving = false;
		vm.submitter = {};
		vm.errorMessage = null;

		function add() {
			vm.saving = true;
		    submitterSvc.add(vm.submitter)
				.success(function () {
					//Close the modal
					$scope.$close();
				})
				.error(function(data) {
					vm.errorMessage = 'There was a problem adding the submitter: ' + data;
				})
				.finally(function() {
					vm.saving = false;
				});
		}
	}
})();