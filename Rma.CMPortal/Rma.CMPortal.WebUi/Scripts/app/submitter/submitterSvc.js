(function() {
    window.app.factory('submitterSvc', submitterSvc);

    submitterSvc.$inject = ['$http'];
    function submitterSvc($http) {
        var submitter = [];

		loadSubmitters();

		var svc = {
			add: add,
			update: update,
			submitters: submitters,
			getSubmitter: getSubmitter
		};

		return svc;

		function loadSubmitters() {
		    $http.post('/Submitter/All')
				.success(function(data) {
				    submitters.addRange(data);
				});

		}

		function add(submitter) {
		    return $http.post('/Submitter/Add', submitter)
				.success(function (submitter) {
				    submitters.unshift(submitter);
				});
		}

		function update(existingSubmitter, updatedSubmitter) {
		    return $http.post('/Submitter/Update', updatedSubmitter)
				.success(function (submitter) {
				    angular.extend(existingSubmitter, submitter);
				});
		}

		function getSubmitter(id) {
		    for (var i = 0; i < submitters.length; i++) {
		        if (submitters[i].Id == id) return submitters[i];
			}

			return null;
		}
	}
})();