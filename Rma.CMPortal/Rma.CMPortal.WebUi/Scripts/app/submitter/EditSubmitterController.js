(function() {
	'use strict';

	window.app.controller('editSubmitterController', editSubmitterController);

	editSubmitterController.$inject = ['$http', 'editSubmitterConfig', 'model'];
	function editSubmitterController($http, editSubmitterConfig, model) {
		var vm = this;

		vm.profile = model;
		vm.save = save;

		function save() {
			vm.saving = true;
			vm.errorMessage = null;
			vm.success = false;

		    $http.post(editSubmitterConfig.saveUrl, vm.profile)
				.success(function() {
					vm.success = true;
				})
				.error(function(msg) {
					vm.errorMessage = msg;
				})
				.finally(function() {
					vm.saving = false;
				});
		}
	}
})();