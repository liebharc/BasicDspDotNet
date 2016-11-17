//! Functions for 32bit floating point number based vectors.
//! Please refer to the other chapters of the help for documentation of the functions.
use super::*;
use basic_dsp_vector::*;
use basic_dsp_vector::window_functions::*;
use basic_dsp_vector::conv_types::*;
use num::complex::Complex32;
use std::slice;
use std::os::raw::c_void;
use std::mem;

pub type VecBuf = InteropVec<f32>;

pub type VecBox = Box<InteropVec<f32>>;

#[no_mangle]
pub extern "C" fn delete_vector32(vector: VecBox) {
    drop(vector);
}


#[no_mangle]
pub extern "C" fn new32(is_complex: i32,
                        domain: i32,
                        init_value: f32,
                        length: usize,
                        delta: f32)
                        -> VecBox {
    let domain = if domain == 0 {
        DataDomain::Time
    } else {
        DataDomain::Frequency
    };

    let mut vector = Box::new(VecBuf {
        vec: vec!(init_value; length).to_gen_dsp_vec(is_complex != 0, domain),
        buffer: SingleBuffer::new(),
    });
    vector.vec.set_delta(delta);
    vector
}

#[no_mangle]
pub extern "C" fn new_with_performance_options32(is_complex: i32,
                                                 domain: i32,
                                                 init_value: f32,
                                                 length: usize,
                                                 delta: f32,
                                                 core_limit: usize,
                                                 early_temp_allocation: bool)
                                                 -> VecBox {
    let domain = if domain == 0 {
        DataDomain::Time
    } else {
        DataDomain::Frequency
    };

    let mut vector = Box::new(VecBuf {
        vec: vec!(init_value; length).to_gen_dsp_vec(is_complex != 0, domain),
        buffer: SingleBuffer::new(),
    });
    vector.vec.set_delta(delta);
    vector.vec.set_multicore_settings(MultiCoreSettings::new(core_limit, early_temp_allocation));
    vector

}

#[no_mangle]
pub extern "C" fn get_value32(vector: &VecBuf, index: usize) -> f32 {
    vector.vec[index]
}

#[no_mangle]
pub extern "C" fn set_value32(vector: &mut VecBuf, index: usize, value: f32) {
    vector.vec[index] = value;
}

#[no_mangle]
pub extern "C" fn is_complex32(vector: &VecBuf) -> i32 {
    if vector.vec.is_complex() { 1 } else { 0 }
}

/// Returns the vector domain as integer:
///
/// 1. `0` for [`DataVecDomain::Time`](../../enum.DataVecDomain.html)
/// 2. `1` for [`DataVecDomain::Frequency`](../../enum.DataVecDomain.html)
///
/// if the function returns another value then please report a bug.
#[no_mangle]
pub extern "C" fn get_domain32(vector: &VecBuf) -> i32 {
    match vector.vec.domain() {
        DataDomain::Time => 0,
        DataDomain::Frequency => 1,
    }
}

#[no_mangle]
pub extern "C" fn get_len32(vector: &VecBuf) -> usize {
    vector.vec.len()
}

#[no_mangle]
pub extern "C" fn set_len32(vector: &mut VecBuf, len: usize) {
    let _ = vector.vec.resize(len);
}

#[no_mangle]
pub extern "C" fn get_points32(vector: &VecBuf) -> usize {
    vector.vec.points()
}

#[no_mangle]
pub extern "C" fn get_delta32(vector: &VecBuf) -> f32 {
    vector.vec.delta()
}

#[no_mangle]
pub extern "C" fn complex_data32(vector: &VecBuf) -> &[Complex32] {
    vector.vec.complex(..)
}

#[no_mangle]
pub extern "C" fn get_allocated_len32(vector: &VecBuf) -> usize {
    vector.vec.alloc_len()
}

#[no_mangle]
pub extern "C" fn add32(vector: Box<VecBuf>, operand: &VecBuf) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.add(&operand.vec))
}

#[no_mangle]
pub extern "C" fn sub32(vector: Box<VecBuf>, operand: &VecBox) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.sub(&operand.vec))
}

#[no_mangle]
pub extern "C" fn div32(vector: Box<VecBuf>, operand: &VecBuf) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.div(&operand.vec))
}

#[no_mangle]
pub extern "C" fn mul32(vector: Box<VecBuf>, operand: &VecBuf) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.mul(&operand.vec))
}

#[no_mangle]
pub extern "C" fn real_dot_product32(vector: &VecBuf,
                                     operand: &VecBuf)
                                     -> ScalarInteropResult<f32> {
    vector.convert_scalar(|v| {
        DotProductOps::<f32, GenDspVec<Vec<f32>, f32>>::dot_product(v, &operand.vec)
    },
    0.0)
}

#[no_mangle]
pub extern "C" fn complex_dot_product32(vector: &VecBuf,
                                        operand: &VecBuf)
                                        -> ScalarInteropResult<Complex32> {
    vector.convert_scalar(|v| {
        DotProductOps::<Complex32, GenDspVec<Vec<f32>, f32>>::dot_product(v, &operand.vec)
    },
    Complex32::new(0.0, 0.0))
}

#[no_mangle]
pub extern "C" fn real_statistics32(vector: &VecBuf) -> Statistics<f32> {
    vector.vec.statistics()
}

#[no_mangle]
pub extern "C" fn complex_statistics32(vector: &VecBuf) -> Statistics<Complex32> {
    vector.vec.statistics()
}

#[no_mangle]
pub extern "C" fn real_sum32(vector: &VecBuf) -> f32 {
    vector.vec.sum()
}

#[no_mangle]
pub extern "C" fn real_sum_sq32(vector: &VecBuf) -> f32 {
    vector.vec.sum_sq()
}

#[no_mangle]
pub extern "C" fn complex_sum32(vector: &VecBuf) -> Complex32 {
    vector.vec.sum()
}

#[no_mangle]
pub extern "C" fn complex_sum_sq32(vector: &VecBuf) -> Complex32 {
    vector.vec.sum_sq()
}

/// `padding_option` argument is translated to:
/// Returns the vector domain as integer:
///
/// 1. `0` for [`PaddingOption::End`](../../enum.PaddingOption.html)
/// 2. `1` for [`PaddingOption::Surround`](../../enum.PaddingOption.html)
/// 2. `2` for [`PaddingOption::Center`](../../enum.PaddingOption.html)
#[no_mangle]
pub extern "C" fn zero_pad32(vector: Box<VecBuf>,
                             points: usize,
                             padding_option: i32)
                             -> VectorInteropResult<VecBuf> {
    let padding_option = translate_to_padding_option(padding_option);
    vector.convert_vec(|v, b| Ok(v.zero_pad_b(b, points, padding_option)))
}

#[no_mangle]
pub extern "C" fn zero_interleave32(vector: Box<VecBuf>,
                                    factor: i32)
                                    -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, b| Ok(v.zero_interleave_b(b, factor as u32)))
}

#[no_mangle]
pub extern "C" fn diff32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.diff()))
}

#[no_mangle]
pub extern "C" fn diff_with_start32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.diff_with_start()))
}

#[no_mangle]
pub extern "C" fn cum_sum32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.cum_sum()))
}

#[no_mangle]
pub extern "C" fn real_offset32(vector: Box<VecBuf>, value: f32) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.offset(value)))
}

#[no_mangle]
pub extern "C" fn real_scale32(vector: Box<VecBuf>, value: f32) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.scale(value)))
}

#[no_mangle]
pub extern "C" fn abs32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.abs()))
}

#[no_mangle]
pub extern "C" fn sqrt32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.sqrt()))
}

#[no_mangle]
pub extern "C" fn square32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.square()))
}

#[no_mangle]
pub extern "C" fn root32(vector: Box<VecBuf>, value: f32) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.root(value)))
}

#[no_mangle]
pub extern "C" fn powf32(vector: Box<VecBuf>, value: f32) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.powf(value)))
}

#[no_mangle]
pub extern "C" fn ln32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.ln()))
}

#[no_mangle]
pub extern "C" fn exp32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.exp()))
}

#[no_mangle]
pub extern "C" fn log32(vector: Box<VecBuf>, value: f32) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.log(value)))
}

#[no_mangle]
pub extern "C" fn expf32(vector: Box<VecBuf>, value: f32) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.expf(value)))
}

#[no_mangle]
pub extern "C" fn to_complex32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.to_complex_b(b)))
}

#[no_mangle]
pub extern "C" fn sin32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.sin()))
}

#[no_mangle]
pub extern "C" fn cos32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.cos()))
}

#[no_mangle]
pub extern "C" fn tan32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.tan()))
}

#[no_mangle]
pub extern "C" fn asin32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.asin()))
}

#[no_mangle]
pub extern "C" fn acos32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.acos()))
}

#[no_mangle]
pub extern "C" fn atan32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.tan()))
}

#[no_mangle]
pub extern "C" fn sinh32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.sinh()))
}
#[no_mangle]
pub extern "C" fn cosh32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.cosh()))
}

#[no_mangle]
pub extern "C" fn tanh32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.tanh()))
}

#[no_mangle]
pub extern "C" fn asinh32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.asinh()))
}

#[no_mangle]
pub extern "C" fn acosh32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.acosh()))
}

#[no_mangle]
pub extern "C" fn atanh32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.atanh()))
}

#[no_mangle]
pub extern "C" fn wrap32(vector: Box<VecBuf>, value: f32) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.wrap(value)))
}

#[no_mangle]
pub extern "C" fn unwrap32(vector: Box<VecBuf>, value: f32) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.unwrap(value)))
}

#[no_mangle]
pub extern "C" fn swap_halves32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, b| Ok(v.swap_halves_b(b)))
}

#[no_mangle]
pub extern "C" fn complex_offset32(vector: Box<VecBuf>,
                                   real: f32,
                                   imag: f32)
                                   -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.offset(Complex32::new(real, imag))))
}

#[no_mangle]
pub extern "C" fn complex_scale32(vector: Box<VecBuf>,
                                  real: f32,
                                  imag: f32)
                                  -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.scale(Complex32::new(real, imag))))
}

#[no_mangle]
pub extern "C" fn complex_divide32(vector: Box<VecBuf>,
                                   real: f32,
                                   imag: f32)
                                   -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.scale(Complex32::new(1.0, 0.0) / Complex32::new(real, imag))))
}

#[no_mangle]
pub extern "C" fn magnitude32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.magnitude_b(b)))
}

#[no_mangle]
pub extern "C" fn get_magnitude32(vector: Box<VecBuf>, destination: &mut VecBuf) -> i32 {
    convert_void(Ok(vector.vec.get_magnitude(&mut destination.vec)))
}

#[no_mangle]
pub extern "C" fn get_magnitude_squared32(vector: Box<VecBuf>, destination: &mut VecBuf) -> i32 {
    convert_void(Ok(vector.vec.get_magnitude_squared(&mut destination.vec)))
}

#[no_mangle]
pub extern "C" fn magnitude_squared32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.magnitude_squared_b(b)))
}

#[no_mangle]
pub extern "C" fn conj32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.conj()))
}

#[no_mangle]
pub extern "C" fn to_real32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.to_real_b(b)))
}

#[no_mangle]
pub extern "C" fn to_imag32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.to_imag_b(b)))
}

#[no_mangle]
pub extern "C" fn map_inplace_real32(vector: Box<VecBuf>,
                                     map: extern "C" fn(f32, usize) -> f32)
                                     -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.map_inplace((), move |v, i, _| map(v, i))))
}

#[no_mangle]
pub extern "C" fn map_inplace_complex32(vector: Box<VecBuf>,
                                        map: extern "C" fn(Complex32, usize) -> Complex32)
                                        -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.map_inplace((), move |v, i, _| map(v, i))))
}

/// Warning: This function interface heavily works around the Rust type system and the safety
/// it provides. Use with great care!
#[no_mangle]
pub extern "C" fn map_aggregate_real32(vector: &VecBuf,
                                       map: extern "C" fn(f32, usize) -> *const c_void,
                                       aggregate: extern "C" fn(*const c_void, *const c_void)
                                                                -> *const c_void)
                                       -> ScalarResult<*const c_void> {
    unsafe {
        let result = vector.convert_scalar(|v| {
            v.map_aggregate((),
                            move |v, i, _| mem::transmute(map(v, i)),
                            move |a: usize, b: usize| {
                                mem::transmute(aggregate(mem::transmute(a), mem::transmute(b)))
                            })
        },
                                           mem::transmute(0usize));
        mem::transmute(result)
    }
}

/// Warning: This function interface heavily works around the Rust type system and the safety
/// it provides. Use with great care!
#[no_mangle]
pub extern "C" fn map_aggregate_complex32(vector: &VecBuf,
                                          map: extern "C" fn(Complex32, usize) -> *const c_void,
                                          aggregate: extern "C" fn(*const c_void, *const c_void)
                                                                   -> *const c_void)
                                          -> ScalarResult<*const c_void> {
    unsafe {
        let result = vector.convert_scalar(|v| {
            v.map_aggregate((),
                            move |v, i, _| mem::transmute(map(v, i)),
                            move |a: usize, b: usize| {
                                mem::transmute(aggregate(mem::transmute(a), mem::transmute(b)))
                            })
        },
                                           mem::transmute(0usize));
        mem::transmute(result)
    }
}

#[no_mangle]
pub extern "C" fn get_real32(vector: Box<VecBuf>, destination: &mut VecBuf) -> i32 {
    convert_void(Ok(vector.vec.get_real(&mut destination.vec)))
}

#[no_mangle]
pub extern "C" fn get_imag32(vector: Box<VecBuf>, destination: &mut VecBuf) -> i32 {
    convert_void(Ok(vector.vec.get_imag(&mut destination.vec)))
}

#[no_mangle]
pub extern "C" fn phase32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.phase_b(b)))
}

#[no_mangle]
pub extern "C" fn get_phase32(vector: Box<VecBuf>, destination: &mut VecBuf) -> i32 {
    convert_void(Ok(vector.vec.get_phase(&mut destination.vec)))
}

#[no_mangle]
pub extern "C" fn plain_fft32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.plain_fft(b)))
}

#[no_mangle]
pub extern "C" fn plain_sfft32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| v.plain_sfft(b))
}

#[no_mangle]
pub extern "C" fn plain_ifft32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.plain_ifft(b)))
}

#[no_mangle]
pub extern "C" fn clone32(vector: Box<VecBuf>) -> Box<VecBuf> {
    Box::new(VecBuf {
        vec: vector.vec.clone(),
        buffer: SingleBuffer::new(),
    })
}

#[no_mangle]
pub extern "C" fn multiply_complex_exponential32(vector: Box<VecBuf>,
                                                 a: f32,
                                                 b: f32)
                                                 -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.multiply_complex_exponential(a, b)))
}

#[no_mangle]
pub extern "C" fn add_vector32(vector: Box<VecBuf>,
                               operand: &VecBuf)
                               -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.add(&operand.vec))
}

#[no_mangle]
pub extern "C" fn sub_vector32(vector: Box<VecBuf>,
                               operand: &VecBuf)
                               -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.sub(&operand.vec))
}

#[no_mangle]
pub extern "C" fn div_vector32(vector: Box<VecBuf>,
                               operand: &VecBuf)
                               -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.div(&operand.vec))
}

#[no_mangle]
pub extern "C" fn mul_vector32(vector: Box<VecBuf>,
                               operand: &VecBuf)
                               -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.mul(&operand.vec))
}

#[no_mangle]
pub extern "C" fn add_smaller_vector32(vector: Box<VecBuf>,
                                       operand: &VecBuf)
                                       -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.add_smaller(&operand.vec))
}

#[no_mangle]
pub extern "C" fn sub_smaller_vector32(vector: Box<VecBuf>,
                                       operand: &VecBuf)
                                       -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.sub_smaller(&operand.vec))
}

#[no_mangle]
pub extern "C" fn div_smaller_vector32(vector: Box<VecBuf>,
                                       operand: &VecBuf)
                                       -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.div_smaller(&operand.vec))
}

#[no_mangle]
pub extern "C" fn mul_smaller_vector32(vector: Box<VecBuf>,
                                       operand: &VecBuf)
                                       -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.mul_smaller(&operand.vec))
}

#[no_mangle]
pub extern "C" fn get_real_imag32(vector: Box<VecBuf>,
                                  real: &mut VecBuf,
                                  imag: &mut VecBuf)
                                  -> i32 {
    convert_void(Ok(vector.vec.get_real_imag(&mut real.vec, &mut imag.vec)))
}

#[no_mangle]
pub extern "C" fn get_mag_phase32(vector: Box<VecBuf>,
                                  mag: &mut VecBuf,
                                  phase: &mut VecBuf)
                                  -> i32 {
    convert_void(Ok(vector.vec.get_mag_phase(&mut mag.vec, &mut phase.vec)))
}

#[no_mangle]
pub extern "C" fn set_real_imag32(vector: Box<VecBuf>,
                                  real: &VecBuf,
                                  imag: &VecBuf)
                                  -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.set_real_imag(&real.vec, &imag.vec))
}

#[no_mangle]
pub extern "C" fn set_mag_phase32(vector: Box<VecBuf>,
                                  mag: &VecBuf,
                                  phase: &VecBuf)
                                  -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| v.set_mag_phase(&mag.vec, &phase.vec))
}

#[no_mangle]
pub extern "C" fn split_into32(vector: &VecBuf, targets: *mut Box<VecBuf>, len: usize) -> i32 {
    unsafe {
        let targets = slice::from_raw_parts_mut(targets, len);
        let mut targets: Vec<&mut GenDspVec<Vec<f32>, f32>> =
            targets.iter_mut().map(|x| &mut x.vec).collect();
        convert_void(vector.vec.split_into(&mut targets))
    }
}

#[no_mangle]
pub extern "C" fn merge32(vector: Box<VecBuf>,
                          sources: *const Box<VecBuf>,
                          len: usize)
                          -> VectorInteropResult<VecBuf> {
    unsafe {
        let sources = slice::from_raw_parts(sources, len);
        let sources: Vec<&GenDspVec<Vec<f32>, f32>> = sources.iter().map(|x| &x.vec).collect();
        vector.convert_vec(|v, _| v.merge(&sources))
    }
}

#[no_mangle]
pub extern "C" fn overwrite_data32(mut vector: Box<VecBuf>,
                                   data: *const f32,
                                   len: usize)
                                   -> VectorInteropResult<VecBuf> {
    let data = unsafe { slice::from_raw_parts(data, len) };
    if len < vector.vec.len() {
        vector.vec[0..len].clone_from_slice(&data);
        VectorInteropResult {
            result_code: 0,
            vector: vector,
        }
    } else {
        VectorInteropResult {
            result_code: translate_error(ErrorReason::InvalidArgumentLength),
            vector: vector,
        }
    }
}

#[no_mangle]
pub extern "C" fn real_statistics_splitted32(vector: &VecBuf,
                                             data: *mut Statistics<f32>,
                                             len: usize)
                                             -> i32 {
    let mut data = unsafe { slice::from_raw_parts_mut(data, len) };
    let stats = vector.vec.statistics_splitted(data.len());
    for i in 0..stats.len() {
        data[i] = stats[i];
    }

    0
}

#[no_mangle]
pub extern "C" fn complex_statistics_splitted32(vector: &VecBuf,
                                                data: *mut Statistics<Complex32>,
                                                len: usize)
                                                -> i32 {
    let mut data = unsafe { slice::from_raw_parts_mut(data, len) };
    let stats = vector.vec.statistics_splitted(data.len());
    for i in 0..stats.len() {
        data[i] = stats[i];
    }

    0
}

#[no_mangle]
pub extern "C" fn fft32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.fft(b)))
}

#[no_mangle]
pub extern "C" fn sfft32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| v.sfft(b))
}

#[no_mangle]
pub extern "C" fn ifft32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.ifft(b)))
}

#[no_mangle]
pub extern "C" fn plain_sifft32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| v.plain_sifft(b))
}

#[no_mangle]
pub extern "C" fn sifft32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| v.sifft(b))
}

#[no_mangle]
pub extern "C" fn mirror32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, b| Ok(v.mirror(b)))
}

pub extern "C" fn fft_shift32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, b| Ok(v.fft_shift(b)))
}

pub extern "C" fn ifft_shift32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, b| Ok(v.ifft_shift(b)))
}

/// `window` argument is translated to:
///
/// 1. `0` to [`TriangularWindow`](../../window_functions/struct.TriangularWindow.html)
/// 2. `1` to [`HammingWindow`](../../window_functions/struct.TriangularWindow.html)
#[no_mangle]
pub extern "C" fn apply_window32(vector: Box<VecBuf>, window: i32) -> VectorInteropResult<VecBuf> {
    let window = translate_to_window_function(window);
    vector.convert_vec(|v, _| Ok(v.apply_window(window.as_ref())))
}

/// See [`apply_window32`](fn.apply_window32.html) for a description of the `window` parameter.
#[no_mangle]
pub extern "C" fn unapply_window32(vector: Box<VecBuf>,
                                   window: i32)
                                   -> VectorInteropResult<VecBuf> {
    let window = translate_to_window_function(window);
    vector.convert_vec(|v, _| Ok(v.unapply_window(window.as_ref())))
}

/// See [`apply_window32`](fn.apply_window32.html) for a description of the `window` parameter.
#[no_mangle]
pub extern "C" fn windowed_fft32(vector: Box<VecBuf>, window: i32) -> VectorInteropResult<VecBuf> {
    let window = translate_to_window_function(window);
    vector.trans_vec(|v, b| Ok(v.windowed_fft(b, window.as_ref())))
}

/// See [`apply_window32`](fn.apply_window32.html) for a description of the `window` parameter.
#[no_mangle]
pub extern "C" fn windowed_sfft32(vector: Box<VecBuf>, window: i32) -> VectorInteropResult<VecBuf> {
    let window = translate_to_window_function(window);
    vector.trans_vec(|v, b| v.windowed_sfft(b, window.as_ref()))
}

/// See [`apply_window32`](fn.apply_window32.html) for a description of the `window` parameter.
#[no_mangle]
pub extern "C" fn windowed_ifft32(vector: Box<VecBuf>, window: i32) -> VectorInteropResult<VecBuf> {
    let window = translate_to_window_function(window);
    vector.trans_vec(|v, b| Ok(v.windowed_ifft(b, window.as_ref())))
}

/// See [`apply_window32`](fn.apply_window32.html) for a description of the `window` parameter.
#[no_mangle]
pub extern "C" fn windowed_sifft32(vector: Box<VecBuf>,
                                   window: i32)
                                   -> VectorInteropResult<VecBuf> {
    let window = translate_to_window_function(window);
    vector.trans_vec(|v, b| v.windowed_sifft(b, window.as_ref()))
}

/// Creates a window from the function `window` and the void pointer `window_data`.
/// The `window_data` pointer is passed to the `window`
/// function at every call and can be used to store parameters.
#[no_mangle]
pub extern "C" fn apply_custom_window32(vector: Box<VecBuf>,
                                        window: extern "C" fn(*const c_void, usize, usize) -> f32,
                                        window_data: *const c_void,
                                        is_symmetric: bool)
                                        -> VectorInteropResult<VecBuf> {
    unsafe {
        let window = ForeignWindowFunction {
            window_function: window,
            window_data: mem::transmute(window_data),
            is_symmetric: is_symmetric,
        };
        vector.convert_vec(|v, _| Ok(v.apply_window(&window)))
    }
}

/// See [`apply_custom_window32`](fn.apply_custom_window32.html) for a description of the
/// `window` and `window_data` parameter.
#[no_mangle]
pub extern "C" fn unapply_custom_window32(vector: Box<VecBuf>,
                                          window: extern "C" fn(*const c_void, usize, usize) -> f32,
                                          window_data: *const c_void,
                                          is_symmetric: bool)
                                          -> VectorInteropResult<VecBuf> {
    unsafe {
        let window = ForeignWindowFunction {
            window_function: window,
            window_data: mem::transmute(window_data),
            is_symmetric: is_symmetric,
        };
        vector.convert_vec(|v, _| Ok(v.unapply_window(&window)))
    }
}

/// See [`apply_custom_window32`](fn.apply_custom_window32.html) for a description of the
/// `window` and `window_data` parameter.
#[no_mangle]
pub extern "C" fn windowed_custom_fft32(vector: Box<VecBuf>,
                                        window: extern "C" fn(*const c_void, usize, usize) -> f32,
                                        window_data: *const c_void,
                                        is_symmetric: bool)
                                        -> VectorInteropResult<VecBuf> {
    unsafe {
        let window = ForeignWindowFunction {
            window_function: window,
            window_data: mem::transmute(window_data),
            is_symmetric: is_symmetric,
        };
        vector.trans_vec(|v, b| Ok(v.windowed_fft(b, &window)))
    }
}

/// See [`apply_custom_window32`](fn.apply_custom_window32.html) for a description of the
/// `window` and `window_data` parameter.
#[no_mangle]
pub extern "C" fn windowed_custom_sfft32(vector: Box<VecBuf>,
                                         window: extern "C" fn(*const c_void, usize, usize) -> f32,
                                         window_data: *const c_void,
                                         is_symmetric: bool)
                                         -> VectorInteropResult<VecBuf> {
    unsafe {
        let window = ForeignWindowFunction {
            window_function: window,
            window_data: mem::transmute(window_data),
            is_symmetric: is_symmetric,
        };
        vector.trans_vec(|v, b| v.windowed_sfft(b, &window))
    }
}

/// See [`apply_custom_window32`](fn.apply_custom_window32.html) for a description of the
/// `window` and `window_data` parameter.
#[no_mangle]
pub extern "C" fn windowed_custom_ifft32(vector: Box<VecBuf>,
                                         window: extern "C" fn(*const c_void, usize, usize) -> f32,
                                         window_data: *const c_void,
                                         is_symmetric: bool)
                                         -> VectorInteropResult<VecBuf> {
    unsafe {
        let window = ForeignWindowFunction {
            window_function: window,
            window_data: mem::transmute(window_data),
            is_symmetric: is_symmetric,
        };
        vector.trans_vec(|v, b| Ok(v.windowed_ifft(b, &window)))
    }
}

/// See [`apply_custom_window32`](fn.apply_custom_window32.html) for a description of the
/// `window` and `window_data` parameter.
#[no_mangle]
pub extern "C" fn windowed_custom_sifft32(vector: Box<VecBuf>,
                                          window: extern "C" fn(*const c_void, usize, usize) -> f32,
                                          window_data: *const c_void,
                                          is_symmetric: bool)
                                          -> VectorInteropResult<VecBuf> {
    unsafe {
        let window = ForeignWindowFunction {
            window_function: window,
            window_data: mem::transmute(window_data),
            is_symmetric: is_symmetric,
        };
        vector.trans_vec(|v, b| v.windowed_sifft(b, &window))
    }
}

#[no_mangle]
pub extern "C" fn reverse32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.reverse()))
}

#[no_mangle]
pub extern "C" fn decimatei32(vector: Box<VecBuf>,
                              decimation_factor: u32,
                              delay: u32)
                              -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, _| Ok(v.decimatei(decimation_factor, delay)))
}

#[no_mangle]
pub extern "C" fn prepare_argument32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.prepare_argument(b)))
}

#[no_mangle]
pub extern "C" fn prepare_argument_padded32(vector: Box<VecBuf>) -> VectorInteropResult<VecBuf> {
    vector.trans_vec(|v, b| Ok(v.prepare_argument_padded(b)))
}

#[no_mangle]
pub extern "C" fn correlate32(vector: Box<VecBuf>, other: &VecBuf) -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, b| v.correlate(b, &other.vec))
}

#[no_mangle]
pub extern "C" fn convolve_vector32(vector: Box<VecBuf>,
                                    impulse_response: &VecBuf)
                                    -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, b| v.convolve_vector(b, &impulse_response.vec))
}

/// Convolves the vector with an impulse response defined by `impulse_response` and
/// the void pointer `impulse_response_data`.
/// The `impulse_response_data` pointer is passed to the `impulse_response`
/// function at every call and can be used to store parameters.
#[no_mangle]
pub extern "C" fn convolve_real32(vector: Box<VecBuf>,
                                  impulse_response: extern "C" fn(*const c_void, f32) -> f32,
                                  impulse_response_data: *const c_void,
                                  is_symmetric: bool,
                                  ratio: f32,
                                  len: usize)
                                  -> VectorInteropResult<VecBuf> {
    unsafe {
        let function: &RealImpulseResponse<f32> = &ForeignRealConvolutionFunction {
            conv_function: impulse_response,
            conv_data: mem::transmute(impulse_response_data),
            is_symmetric: is_symmetric,
        };
        vector.convert_vec(|v, b| Ok(v.convolve(b, function, ratio, len)))
    }
}

/// Convolves the vector with an impulse response defined by `impulse_response` and the
/// void pointer `impulse_response_data`.
/// The `impulse_response_data` pointer is passed to the `impulse_response`
/// function at every call and can be used to store parameters.
#[no_mangle]
pub extern "C" fn convolve_complex32(vector: Box<VecBuf>,
                                     impulse_response: extern "C" fn(*const c_void, f32)
                                                                     -> Complex32,
                                     impulse_response_data: *const c_void,
                                     is_symmetric: bool,
                                     ratio: f32,
                                     len: usize)
                                     -> VectorInteropResult<VecBuf> {
    unsafe {
        let function: &ComplexImpulseResponse<f32> = &ForeignComplexConvolutionFunction {
            conv_function: impulse_response,
            conv_data: mem::transmute(impulse_response_data),
            is_symmetric: is_symmetric,
        };
        vector.convert_vec(|v, b| Ok(v.convolve(b, function, ratio, len)))
    }
}

/// `impulse_response` argument is translated to:
///
/// 1. `0` to [`SincFunction`](../../conv_types/struct.SincFunction.html)
/// 2. `1` to [`RaisedCosineFunction`](../../conv_types/struct.RaisedCosineFunction.html)
///
/// `rolloff` is only used if this is a valid parameter for the selected `impulse_response`
#[no_mangle]
pub extern "C" fn convolve32(vector: Box<VecBuf>,
                             impulse_response: i32,
                             rolloff: f32,
                             ratio: f32,
                             len: usize)
                             -> VectorInteropResult<VecBuf> {
    let function = translate_to_real_convolution_function(impulse_response, rolloff);
    vector.convert_vec(|v, b| Ok(v.convolve(b, function.as_ref(), ratio, len)))
}

/// Convolves the vector with an impulse response defined by `frequency_response` and
/// the void pointer `frequency_response_data`.
/// The `frequency_response_data` pointer is passed to the `frequency_response`
/// function at every call and can be used to store parameters.
#[no_mangle]
pub extern fn multiply_frequency_response_real32(vector: Box<VecBuf>,
    frequency_response: extern fn(*const c_void, f32) -> f32,
    frequency_response_data: *const c_void,
    is_symmetric: bool,
    ratio: f32) -> VectorInteropResult<VecBuf> {
    unsafe {
        let function: &RealFrequencyResponse<f32> = &ForeignRealConvolutionFunction {
            conv_function: frequency_response,
            conv_data: mem::transmute(frequency_response_data),
            is_symmetric: is_symmetric,
        };
        vector.convert_vec(|v, _| Ok(v.multiply_frequency_response(function, ratio)))
    }
}

/// Convolves the vector with an impulse response defined by `frequency_response`
/// and the void pointer `frequency_response_data`.
/// The `frequency_response` pointer is passed to the `frequency_response`
/// function at every call and can be used to store parameters.
#[no_mangle]
pub extern fn multiply_frequency_response_complex32(vector: Box<VecBuf>,
    frequency_response: extern fn(*const c_void, f32) -> Complex32,
    frequency_response_data: *const c_void,
    is_symmetric: bool,
    ratio: f32) -> VectorInteropResult<VecBuf> {
    unsafe {
        let function: &ComplexFrequencyResponse<f32> = &ForeignComplexConvolutionFunction {
            conv_function: frequency_response,
            conv_data: mem::transmute(frequency_response_data),
            is_symmetric: is_symmetric,
        };
        vector.convert_vec(|v, _| Ok(v.multiply_frequency_response(function, ratio)))
    }
}

/// `frequency_response` argument is translated to:
///
/// 1. `0` to [`SincFunction`](../../conv_types/struct.SincFunction.html)
/// 2. `1` to [`RaisedCosineFunction`](../../conv_types/struct.RaisedCosineFunction.html)
///
/// `rolloff` is only used if this is a valid parameter for the selected `frequency_response`
#[no_mangle]
pub extern "C" fn multiply_frequency_response32(vector: Box<VecBuf>,
                                                frequency_response: i32,
                                                rolloff: f32,
                                                ratio: f32)
                                                -> VectorInteropResult<VecBuf> {
    let function = translate_to_real_frequency_response(frequency_response, rolloff);
    vector.convert_vec(|v, _| Ok(v.multiply_frequency_response(function.as_ref(), ratio)))
}

/// Convolves the vector with an impulse response defined by `impulse_response` and
/// the void pointer `impulse_response_data`.
/// The `impulse_response_data` pointer is passed to the `impulse_response`
/// function at every call and can be used to store parameters.
#[no_mangle]
pub extern "C" fn interpolatef_custom32(vector: Box<VecBuf>,
                                        impulse_response: extern "C" fn(*const c_void, f32) -> f32,
                                        impulse_response_data: *const c_void,
                                        is_symmetric: bool,
                                        interpolation_factor: f32,
                                        delay: f32,
                                        len: usize)
                                        -> VectorInteropResult<VecBuf> {
    unsafe {
        let function: &RealImpulseResponse<f32> = &ForeignRealConvolutionFunction {
            conv_function: impulse_response,
            conv_data: mem::transmute(impulse_response_data),
            is_symmetric: is_symmetric,
        };
        vector.convert_vec(|v, b| Ok(v.interpolatef(b, function, interpolation_factor, delay, len)))
    }
}

/// `impulse_response` argument is translated to:
///
/// 1. `0` to [`SincFunction`](../../conv_types/struct.SincFunction.html)
/// 2. `1` to [`RaisedCosineFunction`](../../conv_types/struct.RaisedCosineFunction.html)
///
/// `rolloff` is only used if this is a valid parameter for the selected `impulse_response`
#[no_mangle]
pub extern "C" fn interpolatef32(vector: Box<VecBuf>,
                                 impulse_response: i32,
                                 rolloff: f32,
                                 interpolation_factor: f32,
                                 delay: f32,
                                 len: usize)
                                 -> VectorInteropResult<VecBuf> {
    let function = translate_to_real_convolution_function(impulse_response, rolloff);
    vector.convert_vec(|v, b| {
        Ok(v.interpolatef(b, function.as_ref(), interpolation_factor, delay, len))
    })
}

/// Convolves the vector with an impulse response defined by `frequency_response` and
/// the void pointer `frequency_response_data`.
/// The `frequency_response_data` pointer is passed to the `frequency_response`
/// function at every call and can be used to store parameters.
#[no_mangle]
pub extern "C" fn interpolatei_custom32(vector: Box<VecBuf>,
                                        frequency_response: extern "C" fn(*const c_void, f32)
                                                                          -> f32,
                                        frequency_response_data: *const c_void,
                                        is_symmetric: bool,
                                        interpolation_factor: i32)
                                        -> VectorInteropResult<VecBuf> {
    unsafe {
        let function: &RealFrequencyResponse<f32> = &ForeignRealConvolutionFunction {
            conv_function: frequency_response,
            conv_data: mem::transmute(frequency_response_data),
            is_symmetric: is_symmetric,
        };
        vector.convert_vec(|v, b| v.interpolatei(b, function, interpolation_factor as u32))
    }
}

/// `frequency_response` argument is translated to:
///
/// 1. `0` to [`SincFunction`](../../conv_types/struct.SincFunction.html)
/// 2. `1` to [`RaisedCosineFunction`](../../conv_types/struct.RaisedCosineFunction.html)
///
/// `rolloff` is only used if this is a valid parameter for the selected `frequency_response`
#[no_mangle]
pub extern "C" fn interpolatei32(vector: Box<VecBuf>,
                                 frequency_response: i32,
                                 rolloff: f32,
                                 interpolation_factor: i32)
                                 -> VectorInteropResult<VecBuf> {
    let function = translate_to_real_frequency_response(frequency_response, rolloff);
    vector.convert_vec(|v, b| v.interpolatei(b, function.as_ref(), interpolation_factor as u32))
}

#[no_mangle]
pub extern "C" fn interpolate_lin32(vector: Box<VecBuf>,
                                    interpolation_factor: f32,
                                    delay: f32)
                                    -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, b| Ok(v.interpolate_lin(b, interpolation_factor, delay)))
}

#[no_mangle]
pub extern "C" fn interpolate_hermite32(vector: Box<VecBuf>,
                                        interpolation_factor: f32,
                                        delay: f32)
                                        -> VectorInteropResult<VecBuf> {
    vector.convert_vec(|v, b| Ok(v.interpolate_hermite(b, interpolation_factor, delay)))
}
