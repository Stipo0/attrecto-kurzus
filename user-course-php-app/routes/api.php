<?php

use App\Http\Controllers\CourseController;
use App\Http\Controllers\FrameworkController;
use App\Http\Controllers\UserController;
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

//Órai//

/*Course*/
Route::get('/courses', [CourseController::class, 'index']);
Route::get('/courses/{id}', [CourseController::class, 'show']);
Route::post('/courses',[CourseController::class,'store']);
Route::delete('/courses/{course}',[CourseController::class,'destroy']);
Route::put('/courses/{course}',[CourseController::class,'update']);

/*User*/
Route::post('/users/registration', [UserController::class,'store']);


//Szorgalmi//

/*Framework*/
Route::get('/frameworks', [FrameworkController::class, 'index']);
Route::get('/frameworks/{id}', [FrameworkController::class, 'show']);
Route::post('/frameworks',[FrameworkController::class,'store']);
Route::delete('/frameworks/{framework}',[FrameworkController::class,'destroy']);
Route::put('/frameworks/{framework}',[FrameworkController::class,'update']);
