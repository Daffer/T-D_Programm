#ifndef TABLECALCULATIONFORM_H
#define TABLECALCULATIONFORM_H

#include <QDialog>
#include "tparticle.h"

namespace Ui {
class TableCalculationForm;
}

class TableCalculationForm : public QDialog
{
    Q_OBJECT
    
public:
    explicit TableCalculationForm(QWidget *parent = 0);
    ~TableCalculationForm();
   //  virtual void closeEvent(QCloseEvent *);
signals:
    void closed();
private slots:
    void receive_particles(TParticle *particles,int num);
protected:
    virtual void closeEvent(QCloseEvent *);
private:
    Ui::TableCalculationForm *ui;
};

#endif // TABLECALCULATIONFORM_H
