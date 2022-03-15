<?php

use App\Http\Controllers\CourseController;
use App\Http\Controllers\FrameworkController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

//Órai
Route::get('/courses', [CourseController::class, 'index']);
Route::get('/courses/{id}', [CourseController::class, 'show']);
Route::post('/courses',[CourseController::class,'store']);

//Egyéni
Route::get('/frameworks', [FrameworkController::class, 'index']);
Route::get('/frameworks/{id}', [CourseController::class, 'show']);
Route::post('/frameworks',[CourseController::class,'store']);
