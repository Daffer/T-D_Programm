#include "tparticle.h"

TParticle::TParticle()
{
}
void TParticle::set_particle(float sq, float perim, float len, float wid, float ff, float sm, float diam, float diamG, float el_an)
{
    square = sq;
    perimetr = perim;
    length = len;
    width = wid;
    form_factor = ff;
    smoothness = sm;
    diameter = diam;
    diameterGOST = diamG;
    ellipse_angle = el_an;
    return;
}
void TParticle::set_square(float sq)
{
    square = sq;
    return;
}
void TParticle::set_perimetr(float perim)
{
    perimetr = perim;
    return;
}
void TParticle::set_length(float len)
{
    length = len;
    return;
}
void TParticle::set_width(float wid)
{
    width = wid;
    return;
}
void TParticle::set_form_factor(float ff)
{
    form_factor = ff;
    return;
}
void TParticle::set_smoothness(float sm)
{
    smoothness = sm;
    return;
}
void TParticle::set_diameter(float diam)
{
    diameter = diam;
    return;
}
void TParticle::set_diameterGOST(float diamG)
{
    diameterGOST = diamG;
    return;
}
void TParticle::set_ellipse_angle(float el_an)
{
    ellipse_angle = el_an;
    return;
}
float TParticle::get_square()
{
    return square;
}
float TParticle::get_perimetr()
{
    return perimetr;
}
float TParticle::get_length()
{
    return length;
}
float TParticle::get_width()
{
    return width;
}
float TParticle::get_form_factor()
{
    return form_factor;
}
float TParticle::get_smoothness()
{
    return smoothness;
}
float TParticle::get_diameter()
{
    return diameter;
}
float TParticle::get_diameterGOST()
{
    return diameterGOST;
}
float TParticle::get_ellipse_angle()
{
    return ellipse_angle;
}
