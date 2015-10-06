(function() {
	"use strict";

	window.app.directive('editSubmitter', editSubmitter);

	function editSubmitter() {
		return {
			scope: {
				customer: "="
			},
			templateUrl: '/submitter/template/editSubmitter.tmpl.cshtml',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$scope', 'submitterSvc'];
	function controller($scope, submitterSvc) {
		var vm = this;
		vm.save = save;

		vm.saving = false;
		vm.submitter = angular.copy($scope.submitter);
		vm.errorMessage = null;

		function save() {
			vm.saving = true;
		    submitterSvc.update($scope.submitter, vm.submitter)
				.success(function () {
					//Close the modal
					$scope.$parent.$close();
				})
				.error(function(data) {
				    vm.errorMessage = 'There was a problem saving changes to the submitter: ' + data;
				})
				.finally(function() {
					vm.saving = false;
				});
		}
	}
})();