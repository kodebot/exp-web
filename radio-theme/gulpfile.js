
"use strict";

var gulp = require("gulp");
var less = require("gulp-less");

gulp.task("less", function () {
   gulp.src("./radio-theme.less")
   .pipe(less({paths: "./radio-theme.less"}))
   .pipe(gulp.dest("./"))
});

gulp.task("watch", function(){
   gulp.watch(["*.less"], ["less"]); 
});