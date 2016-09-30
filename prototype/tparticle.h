#ifndef TPARTICLE_H
#define TPARTICLE_H

class TParticle
{
public:
    TParticle();

    void set_particle(float sq,float perim,float len,float wid,float ff,float sm,float diam,float diamG,float el_an);

    void set_square(float sq);
    void set_perimetr(float perim);
    void set_length(float len);
    void set_width(float wid);
    void set_form_factor(float ff);
    void set_smoothness(float sm);
    void set_diameter(float diam);
    void set_diameterGOST(float diamG);
    void set_ellipse_angle(float el_an);

    float get_square();
    float get_perimetr();
    float get_length();
    float get_width();
    float get_form_factor();
    float get_smoothness();
    float get_diameter();
    float get_diameterGOST();
    float get_ellipse_angle();

private:
    float square;
    float perimetr;
    float length;//longsize
    float width;//shortsize
    float form_factor;
    float smoothness;
    float diameter;
    float diameterGOST;
    float ellipse_angle;
};

#endif // TPARTICLE_H
