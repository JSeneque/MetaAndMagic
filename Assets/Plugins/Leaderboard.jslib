mergeInto(LibraryManager.library, {


    updateLeaderboard: function (wallet_address, timestamp, score) {
    //window.alert("Wallet Address: " + UTF8ToString(wallet_address) + " SessionDateTime: " + UTF8ToString(timestamp) + " Score: " + UTF8ToString(score));
    var request  = new Request('https://www.staging.metaandmagic.com/49b98ae1263f6d7abb329ae3660ab3b969fe8850e42dd5da09015bf8b0351efd/'); 
        fetch(request, {method: 'POST', body: JSON.stringify({'wallet_address': UTF8ToString(wallet_address), 'timestamp': UTF8ToString(timestamp), 'score': UTF8ToString(score)})})
        .then(function(response) {return response.json()})
        .then(function(response) {
            console.log(response)
        })
        .catch(function(err) {
            console.log(err)
        })
    },

});