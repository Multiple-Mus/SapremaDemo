function SetVolume(val) {
    document.getElementById("meditation-player").volume = val / 100;
    document.getElementById("vol-control-main").value = val;
    document.getElementById("vol-control-overlay").value = val;
}

function showReviewModal() {
    $('#review-modal').modal('show');
    $('#review-modal').load("ReviewMediation");
}

function fullscreen() {
    document.getElementById("meditation-fullscreen").style.backgroundColor = "rgba(121,134,203, 0.9)";
    breathText = "inhale";
    document.getElementById("meditation-text").innerHTML = breathText;
    document.getElementById("meditation-fullscreen").style.width = "100%";
}

function hideDisplay() {
    document.getElementById("meditation-fullscreen").style.width = "0%";
}

function skipReview() {
    window.location.href = "Meditations";
}

function startMeditation() {
    var audioFile = "../audio/" + '@Model.MeditationName' + ".mp3";
    consol.log(audioFile);
    var audio = document.getElementById("meditation-player");
    document.getElementById("audio-source").src = audioFile;
    audio.play();
    consol.log(audioFile);
}